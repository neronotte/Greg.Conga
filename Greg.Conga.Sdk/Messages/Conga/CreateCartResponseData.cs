using System;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class CreateCartResponseData
	{
		public string Id { get; set; }
		public string OwnerId { get; set; }
		public bool IsDeleted { get; set; }
		public string Name { get; set; }
		public string CurrencyIsoCode { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedById { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public string LastModifiedById { get; set; }
		public DateTime? SystemModstamp { get; set; }
		public DateTime? LastViewedDate { get; set; }
		public DateTime? LastReferencedDate { get; set; }
		public string Apttus_Config2__AccountId__c { get; set; }
		public string Apttus_Config2__BillToAccountId__c { get; set; }
		public string Apttus_Config2__BusinessObjectId__c { get; set; }
		public string Apttus_Config2__BusinessObjectProfile__c { get; set; }
		public string Apttus_Config2__BusinessObjectRefId__c { get; set; }
		public string Apttus_Config2__BusinessObjectType__c { get; set; }
		public string Apttus_Config2__CartDataCache__c { get; set; }
		public string Apttus_Config2__CollaborationRequestId__c { get; set; }
		public DateTime? Apttus_Config2__EffectiveDate__c { get; set; }
		public string Apttus_Config2__EffectivePriceListId__c { get; set; }
		public bool Apttus_Config2__IsPricePending__c { get; set; }
		public bool Apttus_Config2__IsTaskPending__c { get; set; }
		public bool Apttus_Config2__IsTransient__c { get; set; }
		public bool Apttus_Config2__IsValidationPending__c { get; set; }
		public string Apttus_Config2__PriceListId__c { get; set; }
		public string Apttus_Config2__ShipToAccountId__c { get; set; }
		public string Apttus_Config2__Status__c { get; set; }
		public string Apttus_Config2__SummaryGroupType__c { get; set; }
		public string Apttus_Config2__UseType__c { get; set; }
		public int Apttus_Config2__BaseRelationCount__c { get; set; }
		public int Apttus_Config2__NumberOfItems__c { get; set; }
		public bool egl_privacy_marketanalysis__c { get; set; }
		public bool egl_privacy_self_initiative__c { get; set; }
		public bool egl_digitalcomm__c { get; set; }
		public bool egl_immediate_effect__c { get; set; }
		public bool egl_sales_agent_blacklist__c { get; set; }
		public bool egl_troubleshooting_gas_done__c { get; set; }
		public bool egl_troubleshooting_power_done__c { get; set; }
		public bool egl_address_certified_registered__c { get; set; }
		public string egl_sales_process__c { get; set; }
		public bool egl_iscustomercommodity_res__c { get; set; }
		public int APTS_Include_Highlander_Option__c { get; set; }
		public int egl_cart_items__c { get; set; }
		public string Owner_Name__c { get; set; }
		public string egl_sales_channel__c { get; set; }
		public string egl_Administrative_Suspension__c { get; set; }
		public string IsAdministrativeRequest__c { get; set; }
		public string egl_flag_administrative_communication__c { get; set; }
		public string egl_flag_administrative_process__c { get; set; }
		public string egl_skipStateModel__c { get; set; }
	}
}
