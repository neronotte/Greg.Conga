using Greg.Conga.Sdk.Messages.Conga;
using Greg.Conga.Sdk.Messages.Salesforce;
using Greg.Conga.Sdk.TestSuite.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;

namespace Greg.Conga.Sdk.TestSuite
{
	[TestClass]
	public class UnitTest1
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
limit 1000");

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
	}
}
