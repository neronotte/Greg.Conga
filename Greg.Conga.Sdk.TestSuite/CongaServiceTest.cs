using Greg.Conga.Sdk.Messages;
using Greg.Conga.Sdk.Messages.Conga;
using Greg.Conga.Sdk.Messages.Conga.QueryModel;
using Greg.Conga.Sdk.Messages.Salesforce;
using Greg.Conga.Sdk.Model;
using Greg.Conga.Sdk.TestSuite.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Greg.Conga.Sdk
{
	[TestClass]
	public class CongaServiceTest
	{
		private ICongaService GetNewService()
		{
			var endpoint = CongaEndpointFactory.FromFile("C:\\temp\\conga.endpoint.preprod.txt");
			var credentials = CongaCredentialsFactory.FromFile("C:\\temp\\conga.credentials.preprod.txt");

			var congaService = new CongaService(endpoint);
			congaService.Authenticate(credentials);
			return congaService;
		}

		
		[TestMethod]
		public void PaginatedQueryExample()
		{
			var congaService = GetNewService();

			var request = new QueryRequest("select Id, AccountNumber, CreatedDate from account");
			var resultList = new List<DynamicEntity>();
			do
			{
				var response = congaService.Execute<QueryResponse>(request);
				resultList.AddRange(response.Records);
				request = response.GetNextPage();
			}
			while (request != null);


			Assert.AreNotEqual(0, resultList.Count);
		}



		[TestMethod]
		public void CreateCart()
		{
			var congaService = GetNewService();

			var request = new CreateCartRequest
			{
				Name = "Test cart from .net api",
				egl_sales_process__c = "Cambio prodotto"
			};

			var response = congaService.Execute<CreateCartResponse>(request);
			Assert.IsNotNull(response);
			Assert.AreEqual(200, response.Status);
			Assert.AreEqual("success", response.StatusDescription);
		}



		[TestMethod]
		public void GetActivePriceLists()
		{
			var congaService = GetNewService();

			var request = new GetActivePricelistRequest();

			var response = congaService.Execute<GetActivePricelistResponse>(request);
			Assert.IsNotNull(response);
			Assert.AreEqual(200, response.Status);
			Assert.AreEqual("success", response.StatusDescription);
		}


		[TestMethod]
		public void Query()
		{
			var congaService = GetNewService();

			var response = congaService.RetrieveMultiple(@"select Id, CreatedDate
from Apttus_Proposal__Proposal__c
order by CreatedDate desc
limit 10");

			Assert.IsNotNull(response);
		}


		[TestMethod]
		public void DescribeProposal()
		{
			var congaService = GetNewService();
			var request = new DescribeRequest("Apttus_Proposal__Proposal__c");
			var response = congaService.Execute<DescribeResponse>(request);

			Assert.IsNotNull(response);
			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}


		[TestMethod]
		public void CreateCartThenProposal()
		{
			var congaService = GetNewService();

			var request1 = new CreateCartRequest
			{
				Name = "Test cart from .net api",
				egl_sales_process__c = "Cambio prodotto"
			};

			var response1 = congaService.Execute<CreateCartResponse>(request1);

			var request2 = new CreateProposalRequest()
			{
				CartId = response1.Data[0].Id,
				Name = request1.Name
			};


			var response2 = congaService.Execute<CreateProposalResponse>(request2);

			Assert.IsNotNull(response2);

		}


		[TestMethod]
		public void CreateRequest_AnonymousJsonSerialization1()
		{
			var request = new CreateRequest("Account");
			request.Target = new
			{
				Firstname__c = "riccardo",
				Lastname__c = "gregori"
			};

			var expected = @"{
  ""Firstname__c"": ""riccardo"",
  ""Lastname__c"": ""gregori""
}";

			var actual = request.ToSerializedObject();
			Assert.IsNotNull(actual);

			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void CreateRequest_DictionaryJsonSerialization1()
		{
			var request = new CreateRequest("Account");
			request.Target = new Dictionary<string, object>
			{
				{ "Firstname__c", "riccardo" },
				{ "Lastname__c", "gregori" }
			};

			var expected = @"{
  ""Firstname__c"": ""riccardo"",
  ""Lastname__c"": ""gregori""
}";

			var actual = request.ToSerializedObject();
			Assert.IsNotNull(actual);

			Assert.AreEqual(expected, actual);
		}


		class AccountDto
		{
			public string Firstname__c { get; set; }
			public string Lastname__c { get; set; }
		}

		[TestMethod]
		public void CreateRequest_ObjectJsonSerialization1()
		{
			var request = new CreateRequest("Account");
			request.Target = new AccountDto
			{
				Firstname__c = "riccardo",
				Lastname__c = "gregori"
			};

			var expected = @"{
  ""Firstname__c"": ""riccardo"",
  ""Lastname__c"": ""gregori""
}";

			var actual = request.ToSerializedObject();
			Assert.IsNotNull(actual);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CreateRequest_WithBasicFields_ShouldWork()
		{
			var request = new CreateRequest("Account")
			{
				Target = new
				{
					Name = "Riccardo Gregori",
					Firstname__c = "riccardo",
					Lastname__c = "gregori"
				}
			};


			var congaService = GetNewService();
			var response = congaService.Execute<CreateResponse>(request);

			Assert.IsNotNull(response);
			Assert.IsNotNull(response.Id);
			Assert.IsTrue(response.Success);
			Assert.IsNotNull(response.Errors);
			Assert.AreEqual(0, response.Errors.Length);
		}


		[TestMethod]
		public void GetProduct_Test1_ShouldWork()
		{
			var congaService = GetNewService();

			var productId = "01t7a00000AYmTgAAL"; // comevuoi luce 0322v1

			var request1 = new GetProductRequest(productId);
			var response1 = congaService.Execute<GetProductResponse>(request1);

			Assert.IsNotNull(response1);

			var attributes = response1.Data.AttributeGroups.SelectMany(x => x.AttributeGroup.Attributes).OrderBy(x => x.ToString()).ToList();


			var request2 = new GetMultipleProductRulesRequest(productId);
			var response2 = congaService.Execute<GetMultipleProductRulesResponse>(request2);

			Assert.IsNotNull(response2);
		}


		[TestMethod]
		public void Query_GetProductAttributeRules()
		{
			var congaService = GetNewService();

			string productId = "01t7a00000AnInVAAV";

			var request1 = new GetProductRequest(productId);

			var response1 = congaService.Execute<GetProductResponse>(request1);

			var productGroupArray = response1.Data.ProductGroups.Select(x => x.ProductGroupId).ToArray();







			string[] productScopeArray1 = new[] { "", "All" };
			string[] productScopeArray2 = new[] { productId };
			string[] productScopeArray3 = new[] { "Commodity" };
			string[] productScopeArray4 = productGroupArray;

			
			
			var request = new CongaQueryRequest("Apttus_Config2__ProductAttributeRule__c");

			request.AddCondition("Active", ConditionOperator.Equal, true);

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

			var response = congaService.Execute<CongaQueryResponse<Apttus_Config2__ProductAttributeRule__c>>(request);

			Assert.IsNotNull(response);

			var productAttributeRuleActionList = (from productAttributeRule in response.Data
					   from productAttributeRuleAction in productAttributeRule.Apttus_Config2__ProductAttributeRuleActions__r.records
					   orderby productAttributeRuleAction.Apttus_Config2__Action__c
					   select productAttributeRuleAction).ToList();


			var syntesys = (from para in productAttributeRuleActionList
				select new {
					Field = para.Apttus_Config2__Field__c,
					Action = para.Apttus_Config2__Action__c,
					Value = para.Apttus_Config2__ValueExpression__c
				}).Distinct().ToList();


			var actions = productAttributeRuleActionList.Select(x => x.Apttus_Config2__Action__c).Distinct().ToList();

			Assert.IsNotNull(productAttributeRuleActionList);
		}
	}
}
