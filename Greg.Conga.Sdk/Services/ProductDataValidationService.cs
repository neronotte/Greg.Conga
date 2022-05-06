using Greg.Conga.Sdk.Messages.Conga;
using Greg.Conga.Sdk.Messages.Conga.QueryModel;
using Greg.Conga.Sdk.Model;
using Greg.Conga.Sdk.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greg.Conga.Sdk.Services
{
	public class ProductDataValidationService
	{
		private readonly ICongaService congaService;

		public ProductDataValidationService(ICongaService service)
		{
			this.congaService = service;
		}

		

		public bool TryValidate(string productId, Dictionary<string, string> propertyDict, out List<string> validationErrorList)
		{
			var productGroupArray = GetProductGroupsByProductId(productId);


			var rules = GetRules(productId, productGroupArray);

			validationErrorList = new List<string>();

			foreach (var rule in rules)
			{
				if (!rule.TryValidate(propertyDict, out string errorMessage))
				{
					validationErrorList.Add(errorMessage);
				}
			}

			return validationErrorList.Count == 0;
		}



		private string[] GetProductGroupsByProductId(string productId)
		{
			var request1 = new GetProductRequest(productId);
			var response1 = congaService.Execute<GetProductResponse>(request1);
			var productGroupArray = response1.Data.ProductGroups.Select(x => x.ProductGroupId).ToArray();
			return productGroupArray;
		}





		private IReadOnlyCollection<IDataValidationRule> GetRules(string productId, string[] productGroupArray)
		{
			string[] productScopeArray1 = new[] { "", "All" };
			string[] productScopeArray2 = new[] { productId };
			string[] productScopeArray3 = new[] { "Commodity" };
			string[] productScopeArray4 = productGroupArray;

			var request = new CongaQueryRequest("Apttus_Config2__ProductAttributeRule__c");

			request.AddCondition("Active", ConditionOperator.Equal, true);

			var filter1 = request.AddOrFilter();
			filter1.AddCondition("ProductScope", ConditionOperator.In, productScopeArray1);
			filter1.AddCondition("ProductScope", ConditionOperator.In, productScopeArray2);

			var filter2 = request.AddOrFilter();
			filter2.AddCondition("ProductFamilyScope", ConditionOperator.In, productScopeArray1);
			filter2.AddCondition("ProductFamilyScope", ConditionOperator.In, productScopeArray3);

			var filter3 = request.AddOrFilter();
			filter3.AddCondition("ProductGroupScope", ConditionOperator.In, productScopeArray1);
			filter3.AddCondition("ProductGroupScope", ConditionOperator.In, productScopeArray4);

			request.AddChild("Apttus_Config2__ProductAttributeRuleActions__r");

			var response = congaService.Execute<CongaQueryResponse<Apttus_Config2__ProductAttributeRule__c>>(request);

			var ruleList = (from par in response.Data
							from para in par.Apttus_Config2__ProductAttributeRuleActions__r.records
							select new
							{
								Field = para.Apttus_Config2__Field__c,
								Action = para.Apttus_Config2__Action__c,
								Value = para.Apttus_Config2__ValueExpression__c
							})
							.Distinct()
							.Select(x => CreateRule(x.Field, x.Action, x.Value))
							.OrderBy(x => x.Order)
							.ThenBy(x =>x.Field)
							.ToList();

			return ruleList;
		}

		private IDataValidationRule CreateRule(string field, string action, string value)
		{
			switch (action)
			{
				case "Allow": return new DataValidationRuleAllow(field, value);
				case "Default": return new DataValidationRuleDefault(field, value);
				case "Disabled": return new DataValidationRuleDisabled(field);
				case "Hidden": return new DataValidationRuleHidden(field);
				case "Required": return new DataValidationRuleRequired(field);
			}
			throw new ArgumentException("Action not allowed: " + action, nameof(action));
		}
	}
}
