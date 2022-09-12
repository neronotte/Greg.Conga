using Greg.Conga.Sdk.Messages;
using Greg.Conga.Sdk.Messages.Conga;
using Greg.Conga.Sdk.Messages.Conga.Asset;
using Greg.Conga.Sdk.Messages.Conga.Cart;
using Greg.Conga.Sdk.Messages.Conga.QueryModel;
using Greg.Conga.Sdk.Messages.Salesforce;
using Greg.Conga.Sdk.Model;
using Greg.Conga.Sdk.TestSuite.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
		public void CheckDuplicateBillingAccounts()
		{
			var congaService = GetNewService();

			var query = "select egl_billingaccount_id__c, Id, CreatedDate from egl_BillingAccount__c";

			var result = congaService.RetrieveAll<BillingAccountDto>(query);

			Assert.IsNotNull(result);

			var maxValue = result.Max(x => x.egl_billingaccount_id__c);

			var duplicateList = result
				.GroupBy(x =>x.egl_billingaccount_id__c)
				.Where(x => x.Count() > 1)
				.ToList();

			Assert.IsNotNull(duplicateList);

			var toChange = duplicateList.Sum(x => x.Count()) - duplicateList.Count;



			var currentValue = maxValue;

			foreach (var duplicateGroup in duplicateList)
			{
				var stillValue = duplicateGroup.OrderBy(x => x.CreatedDate).First();

				var toUpdate = duplicateGroup.Except(new[] { stillValue }).ToList();

				foreach (var ba in toUpdate)
				{
					currentValue++;

					var response = congaService.Update("egl_BillingAccount__c", ba.Id, new
					{
						egl_billingaccount_id__c = currentValue.ToString()
					});
					Assert.IsNotNull(response);
				}
			}

		}




		[TestMethod]
		public void UpdateContact()
		{
			var congaService = GetNewService();
			var contactId = "0037a00001gDMtOAAW";
			var cf = "JSSLRS83A01C354E";

			congaService.Update("contact", contactId, new
			{
				egl_contact_fiscalcode__c = cf
			});
		}

		
		[TestMethod]
		public void PaginatedQueryExample()
		{
			var congaService = GetNewService();

			var request = new QueryRequest("select Id, AccountNumber, CreatedDate, from account");
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

			var request = new CreateCartRequest(new CartDto
			{
				Name = "Test cart from .net api",
				egl_sales_process__c = "Cambio prodotto"
			}) ;

			var response = congaService.Execute<Messages.Conga.Cart.CreateCartResponse>(request);
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
			Assert.AreEqual("OK", response.StatusDescription);
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

			var cart = new CartDto
			{
				Name = "Test cart from .net api",
				egl_sales_process__c = "Cambio prodotto"
			};

			var request1 = new CreateCartRequest(cart);

			var response1 = congaService.Execute<Messages.Conga.Cart.CreateCartResponse>(request1);

			var request2 = new CreateProposalRequest()
			{
				CartId = response1.Data[0].Id,
				Name = cart.Name
			};


			var response2 = congaService.Execute<CreateProposalResponse>(request2);

			Assert.IsNotNull(response2);

		}


		[TestMethod]
		public void CreateRequest_AnonymousJsonSerialization1()
		{
			var request = new Messages.Salesforce.CreateRequest("Account");
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
			var request = new Messages.Salesforce.CreateRequest("Account");
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
			var request = new Messages.Salesforce.CreateRequest("Account");
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
			var request = new Messages.Salesforce.CreateRequest("Account")
			{
				Target = new
				{
					Name = "Riccardo Gregori",
					Firstname__c = "riccardo",
					Lastname__c = "gregori"
				}
			};


			var congaService = GetNewService();
			var response = congaService.Execute<Messages.Salesforce.CreateResponse>(request);

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









		[TestMethod]
		public void CreateRequest_Francesco()
		{
			var congaService = GetNewService();

			var assetId = "a1k7a000002qmygAAA";

			var asset = congaService.Retrieve<AssetDto>("Apttus_Config2__AssetLineItem__c", assetId, "Apttus_Config2__AccountId__c,Apttus_Config2__StartDate__c,egl_signed_date__c");

			DateTime cartDate = asset.egl_signed_date__c == null
					? asset.Apttus_Config2__StartDate__c == null
					? DateTime.Now.Date
					: asset.Apttus_Config2__StartDate__c.Value
					: asset.egl_signed_date__c.Value;



			var cart = new CartDto();

			cart.Name = "Test per francesco " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
			cart.egl_sales_process__c = "VARIAZIONE TECNICA LAVORI PREVENTIVO AUMENTO POTENZA";
			cart.Apttus_Config2__EffectiveDate__c = cartDate;
			cart.Apttus_Config2__PricingDate__c = cartDate;

			var createCartRequest = new CreateCartRequest(cart);
			createCartRequest.AccountId = asset.Apttus_Config2__AccountId__c;

			var createCartResponse = congaService.Execute<CreateCartResponse>(createCartRequest);

			var cartId = createCartResponse.Data[0].Id;

			var assetChangeRequest = new ChangeAssetRequest(assetId);
			assetChangeRequest.Step = AssetChangeRequest_Step.CHANGE_ASSET;
			assetChangeRequest.CartId = cartId;
			assetChangeRequest.AccountId = asset.Apttus_Config2__AccountId__c;


			var assetChangeResponse = congaService.Execute<ChangeAssetResponse>(assetChangeRequest);
			Assert.IsNotNull(assetChangeResponse);


			var cartPriceRequest = new PriceCartRequest(cartId);
			cartPriceRequest.Mode = CartPriceRequestMode.Default;

			var cartPriceResponse = congaService.Execute<PriceCartResponse>(cartPriceRequest);
			Assert.IsNotNull(cartPriceResponse);

		}



		[TestMethod]
		public void TestDateManagement()
		{
			var service = GetNewService();

			var response = service.Create("egl_order_technical_item__c", new
			{
				egl_lastupdate_timestamp__c = new DateTime(2022, 12,22, 13, 00, 00, DateTimeKind.Local)
			});

			Assert.IsNotNull(response);

			var item1 = service.Retrieve<OTI1>("egl_order_technical_item__c", response.Id, "egl_lastupdate_timestamp__c");
			var item2 = service.Retrieve<OTI2>("egl_order_technical_item__c", response.Id, "egl_lastupdate_timestamp__c");

		}

		class AssetDto
		{
			public string Apttus_Config2__AccountId__c { get; set; }
			public DateTime? Apttus_Config2__StartDate__c { get; set; }

			public DateTime? egl_signed_date__c { get; set; }
		}


		class OTI1
		{
			public string egl_lastupdate_timestamp__c { get; set; }
		}
		class OTI2
		{
			public DateTime egl_lastupdate_timestamp__c { get; set; }
		}

		class BillingAccountDto
		{
			public string Id { get; set; }
			public double egl_billingaccount_id__c { get; set; }

			public DateTime CreatedDate { get; set; }
		}
	}
}
