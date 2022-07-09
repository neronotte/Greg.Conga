using System;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetActivePricelistResponseData
	{
#pragma warning disable CA1707 // Identifiers should not contain underscores
		public string Id { get; set; }
		public string OwnerId { get; set; }
		public string Name { get; set; }
		public string Apttus_Config2__Type__c { get; set; }
		public bool Apttus_Config2__Active__c { get; set; }
		public bool Apttus_Config2__DisableBasedOnCurrencyAdjustment__c { get; set; }
		public string APTS_Ext_ID__c { get; set; }
		public string CurrencyIsoCode { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedById { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public string LastModifiedById { get; set; }
		public DateTime? SystemModstamp { get; set; }
		public string IsDeleted { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
	}
}
