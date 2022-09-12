using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Conga.Sdk.Messages.Conga.Cart
{
	public class CartDto
	{
		public string Id { get; set; }

		public string Name { get; set; }

#pragma warning disable CA1707 // Identifiers should not contain underscores
		public string egl_sales_process__c { get; set; }
		public DateTime? Apttus_Config2__EffectiveDate__c { get; set; }
		public DateTime? Apttus_Config2__PricingDate__c { get; set; }

#pragma warning restore CA1707 // Identifiers should not contain underscores
	}
}
