using Greg.Conga.Sdk.TestSuite.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Services
{
	[TestClass]
	public class ProdutDataValidationServiceTest
	{
		


		[TestMethod]
		public void RequiredFieldsMissing()
		{
			var congaService = CongaServiceFactory.GetNewService();
			var service = new ProductDataValidationService(congaService);


			var productId = "01t7a00000AnInVAAV";

			var properties = new Dictionary<string, string>();

			var result = service.TryValidate(productId, properties, out List<string> validationErrors);

			Assert.IsFalse(result);
		}
	}
}
