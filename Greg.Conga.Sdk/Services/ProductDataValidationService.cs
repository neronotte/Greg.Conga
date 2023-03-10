using Greg.Conga.Sdk.Messages.Conga;
using Greg.Conga.Sdk.Messages.Conga.QueryModel;
using Greg.Conga.Sdk.Model;
using Greg.Conga.Sdk.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greg.Conga.Sdk.Services
{
	public class ProductDataValidationService
	{
		private readonly ICongaService congaService;

		public ProductDataValidationService(ICongaService service)
		{
			this.congaService = service;
		}


		public async Task<(bool Result, List<string> ValidationErrorList)> TryValidateAsync(string productId, Dictionary<string, string> propertyDict, string salesProcess)
		{
			var productGroupArray = await GetProductGroupsByProductIdAsync(productId);
			var rules = await GetRulesAsync(productId, productGroupArray, salesProcess);

			var validationErrorList = new List<string>();
			foreach (var rule in rules)
			{
				if (rule.IsEnabled && !rule.TryValidate(propertyDict, out string errorMessage))
				{
					validationErrorList.Add(errorMessage);
				}
			}
			return (validationErrorList.Count == 0, validationErrorList);
		}





		private async Task<string[]> GetProductGroupsByProductIdAsync(string productId)
		{
			var request1 = new GetProductRequest(productId);
			var response1 = await congaService.ExecuteAsync<GetProductResponse>(request1);
			var productGroupArray = response1.Data.ProductGroups.Select(x => x.ProductGroupId).ToArray();
			return productGroupArray;
		}


		private static CongaQueryRequest CreateQueryForProductAttributes(string productId, string[] productGroupArray)
		{
			string[] productScopeArray1 = new[] { "", "All" };
			string[] productScopeArray2 = new[] { productId };
			string[] productScopeArray3 = new[] { "Commodity" };
			string[] productScopeArray4 = productGroupArray;


			var request = new CongaQueryRequest("Apttus_Config2__ProductAttributeRule__c");

			request.AddCondition("Active", ConditionOperator.Equal, true);

			//// devo escludere le regole condizionali
			//request.AddCondition("Apttus_Config2__ConditionCriteriaExpression__c", ConditionOperator.);

			var filter1 = request.AddOrFilter();
			filter1.AddCondition("ProductScope", ConditionOperator.In, productScopeArray1);
			filter1.AddCondition("ProductScope", ConditionOperator.Includes, productScopeArray2);

			var filter2 = request.AddOrFilter();
			filter2.AddCondition("ProductFamilyScope", ConditionOperator.In, productScopeArray1);
			filter2.AddCondition("ProductFamilyScope", ConditionOperator.Includes, productScopeArray3);

			var filter3 = request.AddOrFilter();
			filter3.AddCondition("ProductGroupScope", ConditionOperator.In, productScopeArray1);
			filter3.AddCondition("ProductGroupScope", ConditionOperator.Includes, productScopeArray4);

			request.AddChild("Apttus_Config2__ProductAttributeRuleActions__r");

			return request;
		}


		private async Task<IReadOnlyCollection<IDataValidationRule>> GetRulesAsync(string productId, string[] productGroupArray, string salesProcess)
		{
			/*
1) dato il prodotto, recupero tutti gli attribute group di quel prodotto
2) dalla lista degli attribute group, tolgo quelli che hanno sequence = 7
3) dalla lista di quelli rimasti, se il campo "salesprocess" vale ALL o vuoto lo tengo, se iniza con ALL_BUT, devo escludere il gruppo se il SP corrente è nel campo; altrimenti lo devo escludere se non è nel campo.
4) dalla lista degli attributegroup recupero in distinct la lista degli attributi (query sopra)
5) questi attributi vanno passati alle regole di Required e Disabled, facendo in modo di restituire "true" se il campo a cui si applica la regola non è nella lista di cui sopra.
			*/

			var validAttributesList = await GetValidAttributesByProductIdAsync(productId, salesProcess);
			var request = CreateQueryForProductAttributes(productId, productGroupArray);
			var response = await congaService.ExecuteAsync<CongaQueryResponse<Apttus_Config2__ProductAttributeRule__c>>(request);
			var ruleList = ConvertQueryResponseToRuleList(response, validAttributesList);
			return ruleList;
		}


		public async Task<List<string>> GetValidAttributesByProductIdAsync(string productId, string salesProcess)
		{
			// 1) dato il prodotto, recupero tutti gli attribute group di quel prodotto
			var query = @"SELECT Id, Apttus_Config2__AttributeGroupId__c, Apttus_Config2__Sequence__c, egl_SalesProcess__c 
FROM Apttus_Config2__ProductAttributeGroupMember__c
WHERE Apttus_Config2__ProductId__c = '@productId'".Replace("@productId", productId);

			var response1 = await this.congaService.RetrieveAllAsync<Apttus_Config2__ProductAttributeGroupMember__c>(query);

			var groupList = response1
				// 2) dalla lista degli attribute group, tolgo quelli che hanno sequence = 7
				.Where(x => x.Apttus_Config2__Sequence__c <= 6.99 || x.Apttus_Config2__Sequence__c >= 7.01)
				// 3) valido il sales process
				.Where(x => ValidateSalesProcess(x.egl_SalesProcess__c, salesProcess))
				.Select(x=> x.Apttus_Config2__AttributeGroupId__c)
				.Distinct()
				.ToList();

			if (groupList.Count == 0)
			{
				return new List<string>();
			}

			var groupIds = string.Join(", ", groupList.Select(x => $"'{x}'"));

			query =
@"SELECT 
	Id,
	Apttus_Config2__Field__c
FROM 
	Apttus_Config2__ProductAttribute__c
WHERE 
	Apttus_Config2__AttributeGroupId__c IN (@groups)
ORDER BY Apttus_Config2__Sequence__c"
	.Replace("@groups", groupIds);

			var response2 = await this.congaService.RetrieveAllAsync<Apttus_Config2__ProductAttribute__c>(query);
			var attributeList = response2
				.Select(x => "Apttus_Config2__ProductAttributeValue__c." + x.Apttus_Config2__Field__c)
				.Distinct()
				.OrderBy(x => x)
				.ToList();

			return attributeList;
		}



		/// <summary>
		/// dalla lista di quelli rimasti,
		///		se il campo "salesprocess" vale ALL o vuoto lo tengo, 
		///		se iniza con ALL_BUT, devo tenerlo se il SP corrente non è nel campo; 
		///		altrimenti lo devo tenere se è nel campo.
		/// </summary>
		/// <param name="salesProcessInRule"></param>
		/// <param name="salesProcessCurrent"></param>
		/// <returns></returns>
		private static bool ValidateSalesProcess(string salesProcessInRule, string salesProcessCurrent)
		{
			if (string.IsNullOrWhiteSpace(salesProcessInRule)) return true;
			if (string.Equals(salesProcessInRule, "ALL", StringComparison.OrdinalIgnoreCase)) return true;

			if (salesProcessInRule.StartsWith("ALL_BUT", StringComparison.OrdinalIgnoreCase))
			{
				var validSalesProcesses = salesProcessInRule.Substring("ALL_BUT".Length + 1).Split('|');
				return !validSalesProcesses.Any(x => salesProcessCurrent.Equals(x, StringComparison.OrdinalIgnoreCase));
			}
			else
			{
				var validSalesProcesses = salesProcessInRule.Split('|');
				return validSalesProcesses.Any(x => salesProcessCurrent.Equals(x, StringComparison.OrdinalIgnoreCase));
			}
		}



		private static IReadOnlyCollection<IDataValidationRule> ConvertQueryResponseToRuleList(CongaQueryResponse<Apttus_Config2__ProductAttributeRule__c> response, List<string> validAttributeList)
		{
			var ruleList = (from par in response.Data
							where string.IsNullOrWhiteSpace(par.Apttus_Config2__ConditionCriteriaExpression__c) // devo escludere le regole condizionali
							from para in par.Apttus_Config2__ProductAttributeRuleActions__r.records
							select new
							{
								Field = para.Apttus_Config2__Field__c,
								Action = para.Apttus_Config2__Action__c,
								Value = para.Apttus_Config2__ValueExpression__c
							})
							.Distinct()
							.Select(x => CreateRule(x.Field, x.Action, x.Value, IsAllowed(x.Field, x.Action, validAttributeList)))
							.OrderBy(x => x.Order)
							.ThenBy(x => x.Field)
							.ToList();

			return ruleList;
		}

		private static bool IsAllowed(string field, string action, List<string> validAttributeList)
		{
			if (action != "Disabled" && action != "Required") return true;
			return validAttributeList.Contains(field);
		}




		private static IDataValidationRule CreateRule(string field, string action, string value, bool isEnabled)
		{
			switch (action)
			{
				case "Allow": return new DataValidationRuleAllow(field, value, isEnabled);
				case "Default": return new DataValidationRuleDefault(field, value, isEnabled);
				case "Disabled": return new DataValidationRuleDisabled(field, isEnabled);
				case "Hidden": return new DataValidationRuleHidden(field, isEnabled);
				case "Required": return new DataValidationRuleRequired(field, isEnabled);
			}
			throw new ArgumentException("Action not allowed: " + action, nameof(action));
		}
	}
}
