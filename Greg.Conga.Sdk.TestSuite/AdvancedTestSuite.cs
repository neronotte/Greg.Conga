using Greg.Conga.Sdk.Messages.Conga;
using Greg.Conga.Sdk.Messages.Conga.Asset;
using Greg.Conga.Sdk.Messages.Conga.Cart;
using Greg.Conga.Sdk.Messages.Salesforce;
using Greg.Conga.Sdk.TestSuite.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Greg.Conga.Sdk
{
	[TestClass]
	public class AdvancedTestSuite
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
		public void Test001()
		{
			var conga = GetNewService();

			var req1 = new CreateCartRequest(new
			{
				egl_sales_process = "SWITCH IN"
			});

			var res1 = conga.Execute<CreateCartResponse>(req1);
			Assert.IsNotNull(res1.Data);
			Assert.AreEqual(1, res1.Data.Length);

			var cartId = res1.Data[0].Id;


			var req2 = new AddProductToCartRequest(cartId);
			req2.ProductId = "01t7a00000AQ7OzAAL";
			req2.Quantity = 1;
			req2.ProductAttributes = new
			{
				egl_POD__c = "IT951E00000000"
			};

			var res2 = conga.Execute<AddProductToCartResponse>(req2);
			Assert.IsNotNull(res2.Data);
		}



		[TestMethod]
		public void TestComposite01()
		{
			var conga = GetNewService();



			var req1 = new QueryRequest("SELECT Id FROM Account LIMIT 10");
			var req2 = new QueryRequest("select Id, egl_federationidentifier__c from User order by egl_federationidentifier__c");
			//var req3 = new QueryRequest("select Id from Apttus_Config2__AssetLineItem__c where egl_POD_PDR__c = '00881112768880'");

			var sw2 = Stopwatch.StartNew();
			var res1 = conga.Execute<QueryResponse>(req1);
			var res2 = conga.Execute<QueryResponse>(req2);
			//var res3 = conga.Execute<QueryResponse>(req3);
			sw2.Stop();



			var request = new CompositeRequest();
			request.Add(HttpMethod.Get, "/services/data/v54.0/query?q=SELECT Id FROM Account LIMIT 10", "Query1");
			request.Add(HttpMethod.Get, "/services/data/v54.0/query?q=select Id, egl_federationidentifier__c from User order by egl_federationidentifier__c", "Query2");
			//request.Add(HttpMethod.Get, "/services/data/v54.0/query?q=select Id from Apttus_Config2__AssetLineItem__c where egl_POD_PDR__c = '00881112768880'", "Query3");

			var sw1 = Stopwatch.StartNew();
			var response = conga.Execute<CompositeResponse>(request);
			Assert.IsNotNull(response);
			Assert.IsNotNull(response.Children);
			Assert.AreEqual(request.Children.Count, response.Children.Count);
			sw1.Stop();


			Assert.IsTrue(sw1.Elapsed < sw2.Elapsed);

		}
		[TestMethod]
		public void TestComposite02()
		{
			var conga = GetNewService();

			var request = new CompositeRequest
			{
				AllOrNone = true
			};

			request.Add(HttpMethod.Post, "/services/apexrest/asset/check/v1", "Asset1", new
			{
				AssetId = "a1k7a000001ln59AAA",
				SalesProcess = "CAMBIO PRODOTTO"
			});

			var response = conga.Execute<CompositeResponse>(request);
			Assert.IsNotNull(response);
			Assert.IsNotNull(response.Children);
			Assert.AreEqual(1, response.Children.Count);
		}


		[TestMethod]
		public void TestSwitchOut01()
		{
			var stagingId = "_RG_" + Guid.NewGuid().ToString("N");
			var assetId = "a1k7a000002s4lkAAA";
			var supplyAssetId = "a1k7a000002rGpeAAE";
			var gtwCode = "RG_GTW_1234";
			var contractCode = "RG_CONTRACT_1234";
			var cancelDate = DateTime.Now;

			var conga = GetNewService();

			var request = new CompositeRequest
			{
				AllOrNone = true
			};

			request.Add(HttpMethod.Get, $"/services/data/v54.0/sobjects/Apttus_Config2__AssetLineItem__c/{assetId}?fields=Id,Apttus_Config2__AccountId__c,egl_signed_date__c", "Asset1");


			request.Add(HttpMethod.Post, "/services/apexrest/Apttus_WebStore/apttus/v4/carts?alias=false", "Cart1", new
			{
				egl_sales_process__c = "SWITCH OUT",
				egl_staging_EXT_id__c = stagingId,
				egl_system_source__c = "BPM",
				Apttus_Config2__AccountId__c = "@{Asset1.Apttus_Config2__AccountId__c}",
				Apttus_Config2__PricingDate__c = "@{Asset1.egl_signed_date__c}",
				egl_codice_pratica_GTW__c = gtwCode,
				Apttus_Config2__EffectiveDate__c = "@{Asset1.egl_signed_date__c}",
				egl_contract_code__c = contractCode,
				egl_Effective_date__c = cancelDate
			},
			new CreateCartHeader("@{Asset1.Apttus_Config2__AccountId__c}"));


			request.Add(HttpMethod.Post, "/services/apexrest/Apttus_WebStore/apttus/v4/assets/@{Cart1.id}/terminate", "Terminate1", new
			{
				AssetIds = new string[] { assetId, supplyAssetId },
				cancelDate = cancelDate
			});

			request.Add(HttpMethod.Post, "/services/apexrest/Apttus_WebStore/apttus/v4/assets/@{Cart1.id}/proposal", "Quote1", new
			{
				egl_sales_process__c = "SWITCH OUT",
				egl_signed_date__c = "@{Asset1.egl_signed_date__c}",
				egl_Bulk__c = true,
				egl_contract_code__c = contractCode
			});




			var response = conga.Execute<CompositeResponse>(request);
			Assert.IsNotNull(response);
			Assert.IsNotNull(response.Children);
			Assert.AreEqual(2, response.Children.Count);

		}


		[TestMethod]
		public void TestSwitchOut02()
		{
			var stagingId = ("RG" + Guid.NewGuid().ToString("N")).Substring(0,18);
			var assetId = "a1k7a000002s4lkAAA";
			var gtwCode = "RG_GTW_1234";
			var contractCode = "RG_CONTRACT_1234";
			var cancelDate = DateTime.Now; //.ToString("s") + ".00+02:00";

			var conga = GetNewService();




			var asset = conga.Retrieve<AssetLineItemDto>("Apttus_Config2__AssetLineItem__c", assetId, "Id,Apttus_Config2__AccountId__c,egl_signed_date__c,egl_supply_asset_id__c".Split(','));


			var signedDate = asset.egl_signed_date__c;
			var signedDateFormatted = signedDate?.ToString("yyyy-MM-dd"); //signedDate?.ToString("s") + ".00+02:00"; // controllare se è null o meno

			var req1 = new CreateCartRequest(new {
				egl_sales_process__c = "SWITCH OUT",
				egl_staging_EXT_id__c = stagingId,
				egl_system_source__c = "BPM",
				Apttus_Config2__AccountId__c = asset.Apttus_Config2__AccountId__c,
				Apttus_Config2__PricingDate__c = signedDateFormatted,
				egl_codice_pratica_GTW__c = gtwCode,
				Apttus_Config2__EffectiveDate__c = signedDateFormatted,
				egl_contract_code__c = contractCode,
				egl_Effective_date__c = cancelDate.ToString("yyyy-MM-dd")
			});
			req1.AccountId = asset.Apttus_Config2__AccountId__c;

			var res1 = conga.Execute<CreateCartResponse>(req1);

			Assert.IsNotNull(res1);
			Assert.IsNotNull(res1.Data);
			Assert.AreEqual(1, res1.Data.Length);

			var cart = res1.Data[0];

			var req2 = new TerminateAssetRequest(cart.Id)
			{
				CancelDate = cancelDate,
				AssetIds = new[] { assetId, asset.egl_supply_asset_id__c }
			};

			var res2 = conga.Execute<TerminateAssetResponse>(req2);

			Assert.IsNotNull(res2);
			Assert.IsNotNull(res2.Data);



			var req3 = new CreateProposalFromCartRequest(cart.Id, new
			{
				egl_sales_process__c = "SWITCH OUT",
				egl_signed_date__c = signedDateFormatted,
				egl_Bulk__c = true,
				egl_contract_code__c = contractCode
			});


			var res3 = conga.Execute<CreateProposalFromCartResponse>(req3);

			Assert.IsNotNull(res3);
			Assert.IsNotNull(res3.Raw);
		}
	



		[TestMethod]
		public void TestSwitchOut03()
		{
			var stagingId = ("RG" + Guid.NewGuid().ToString("N")).Substring(0, 18);
			var assetId = "a1k7a000002s4lkAAA";
			var gtwCode = "RG_GTW_1234";
			var contractCode = "RG_CONTRACT_1234";
			var cancelDate = DateTime.Now; //.ToString("s") + ".00+02:00";

			var conga = GetNewService();

			var query1 = $"SELECT Id FROM Apttus_Config2__AssetLineItem__c WHERE Apttus_Config2__AccountId__c = '@{{Asset1.Apttus_Config2__AccountId__c}}' and Apttus_Config2__AssetStatus__c in ('Activated','Pending Activation') and Apttus_Config2__LineType__c = 'Product/Service' and Apttus_Config2__IsPrimaryLine__c = true and Apttus_Config2__ProductType__c like '%25commodity%25' and id <> '{assetId}' LIMIT 1";//.Replace(" ", "+");
			var query2 = $"SELECT id FROM Apttus_Config2__AssetLineItem__c where Apttus_Config2__AccountId__c = '@{{Asset1.Apttus_Config2__AccountId__c}}' and Apttus_Config2__AssetStatus__c in ('Activated','Pending Activation') and Name = 'Partnership Fastweb' LIMIT 1";//.Replace(" ", "+");


			var req0 = new CompositeRequest();
			req0.AllOrNone = true;
			req0.Add(HttpMethod.Get, $"/services/data/v54.0/sobjects/Apttus_Config2__AssetLineItem__c/{assetId}?fields=Id,Apttus_Config2__AccountId__c,egl_signed_date__c", "Asset1");
			req0.Add(HttpMethod.Get, $"/services/data/v54.0/query?q=" + query1, "Other1");
			req0.Add(HttpMethod.Get, $"/services/data/v54.0/query?q=" + query2, "Partnership1");


			var res0 = conga.Execute<CompositeResponse>(req0);
			Assert.IsNotNull(res0);
			if (res0.Children.Count != 3)
				Assert.Fail("Composite request failed, child count is != 3");
			if (res0.Children[0].Error != null)
				Assert.Fail("Composite request failed: " + res0.Children[0].Error.ToString());

			var asset = res0.Children[0].GetBody<AssetLineItemDto>();
			if (asset == null)
				Assert.Fail("Composite request failed: " + res0.Children[0].Error.ToString());


			var otherAsset = res0.Children[1].GetBody<QueryResponse<AssetLineItemDto>>()?.Records?.FirstOrDefault();
			var parthershipAsset = res0.Children[2].GetBody<QueryResponse<AssetLineItemDto>>()?.Records?.FirstOrDefault();


			// inserisco nella lista degli asset da terminare anche quello di partnership
			// se non è presente un altro asset di tipo commodity
			var assetIdToTerminate = new List<string>();
			assetIdToTerminate.Add(asset.Id);
			assetIdToTerminate.Add(asset.egl_supply_asset_id__c);
			if (otherAsset == null && parthershipAsset != null)
				assetIdToTerminate.Add(parthershipAsset.Id);





			



			var signedDate = asset.egl_signed_date__c;
			var signedDateFormatted = signedDate?.ToString("yyyy-MM-dd"); //signedDate?.ToString("s") + ".00+02:00"; // controllare se è null o meno

			var req1 = new CreateCartRequest(new
			{
				egl_sales_process__c = "SWITCH OUT",
				egl_staging_EXT_id__c = stagingId,
				egl_system_source__c = "BPM",
				Apttus_Config2__AccountId__c = asset.Apttus_Config2__AccountId__c,
				Apttus_Config2__PricingDate__c = signedDateFormatted,
				egl_codice_pratica_GTW__c = gtwCode,
				Apttus_Config2__EffectiveDate__c = signedDateFormatted,
				egl_contract_code__c = contractCode,
				egl_Effective_date__c = cancelDate.ToString("yyyy-MM-dd")
			});
			req1.AccountId = asset.Apttus_Config2__AccountId__c;

			var res1 = conga.Execute<CreateCartResponse>(req1);

			Assert.IsNotNull(res1);
			Assert.IsNotNull(res1.Data);
			Assert.AreEqual(1, res1.Data.Length);

			var cart = res1.Data[0];

			var req2 = new TerminateAssetRequest(cart.Id)
			{
				CancelDate = cancelDate,
				AssetIds = assetIdToTerminate.ToArray()
			};

			var res2 = conga.Execute<TerminateAssetResponse>(req2);

			Assert.IsNotNull(res2);
			Assert.IsNotNull(res2.Data);



			var req3 = new CreateProposalFromCartRequest(cart.Id, new
			{
				egl_sales_process__c = "SWITCH OUT",
				egl_signed_date__c = signedDateFormatted,
				egl_Bulk__c = true,
				egl_contract_code__c = contractCode
			});


			var res3 = conga.Execute<CreateProposalFromCartResponse>(req3);

			Assert.IsNotNull(res3);
			Assert.IsNotNull(res3.Raw);
		}








		class AssetLineItemDto
		{
			public string Id { get; set; }
			public string Apttus_Config2__AccountId__c { get; set; }
			public string egl_supply_asset_id__c { get; set; }
			public DateTime? egl_signed_date__c {get; set;}
		}

		class CreateCartHeader
		{
			public CreateCartHeader(string accountId)
			{
				this.AccountId = accountId;
			}
			[JsonProperty(PropertyName = "x-account")]
			public string AccountId { get; set; }
		}
	}
}
