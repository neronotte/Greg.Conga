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

			var productId = "01t7a00000DVux6AAD";

			var properties = new Dictionary<string, string>();
			properties["Apttus_Config2__ProductAttributeValue__c.egl_POD__c"] = "IT001E9878225";
			properties["Apttus_Config2__ProductAttributeValue__c.egl_power_consumption_declared__c"] = "1200";
			properties["Apttus_Config2__ProductAttributeValue__c.egl_power_consumption__c"] = "1200";
			properties["Apttus_Config2__ProductAttributeValue__c.egl_isresidential__c"] = "true";
			properties["Apttus_Config2__ProductAttributeValue__c.egl_Hours_Bundle__c"] = "Monoraria";
			properties["Apttus_Config2__ProductAttributeValue__c.egl_combined_sale_insurance__c"] = "No";

			var task = service.TryValidateAsync(productId, properties, "SWITCH IN");

			task.Wait();

			var result = task.Result;

			Assert.IsTrue(result.Result);
		}
	}
}