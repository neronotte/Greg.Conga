using Greg.Conga.Sdk.Messages.Conga;
using Greg.Conga.Sdk.Messages.Conga.Cart;
using Greg.Conga.Sdk.TestSuite.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
	}
}
