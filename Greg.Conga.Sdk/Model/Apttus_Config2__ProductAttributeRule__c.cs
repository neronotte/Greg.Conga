using System;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Model
{


	[DebuggerDisplay("{Name}")]
	public class Apttus_Config2__ProductAttributeRule__c
	{
		public Attributes attributes { get; set; }
		public string Id { get; set; }
		public string OwnerId { get; set; }
		public bool IsDeleted { get; set; }
		public string Name { get; set; }
		public string CurrencyIsoCode { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedById { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public string LastModifiedById { get; set; }
		public DateTime SystemModstamp { get; set; }
		public bool Apttus_Config2__Active__c { get; set; }
		public string Apttus_Config2__ConditionCriteriaExpression__c { get; set; }
		public string Apttus_Config2__ProductFamilyScopeOper__c { get; set; }
		public string Apttus_Config2__ProductFamilyScope__c { get; set; }
		public string Apttus_Config2__ProductGroupScopeOper__c { get; set; }
		public string Apttus_Config2__ProductGroupScope__c { get; set; }
		public string Apttus_Config2__ProductScopeOper__c { get; set; }
		public string Apttus_Config2__ProductScope__c { get; set; }
		public string APTS_Ext_ID__c { get; set; }
		public ProductAttributeRuleActionList Apttus_Config2__ProductAttributeRuleActions__r { get; set; }
	}

	[DebuggerDisplay("{type}")]
	public class Attributes
	{
		public string type { get; set; }
		public string url { get; set; }
	}

	public class ProductAttributeRuleActionList
	{
		public int totalSize { get; set; }
		public bool done { get; set; }
		public Apttus_Config2__ProductAttributeRuleActions__c[] records { get; set; }
	}

	[DebuggerDisplay("{Apttus_Config2__Field__c} --> {Apttus_Config2__Action__c}")]
	public class Apttus_Config2__ProductAttributeRuleActions__c
	{
		public Attributes attributes { get; set; }
		public string Apttus_Config2__ProductAttributeRuleId__c { get; set; }
		public string Id { get; set; }
		public bool IsDeleted { get; set; }
		public string Name { get; set; }
		public string CurrencyIsoCode { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedById { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public string LastModifiedById { get; set; }
		public DateTime SystemModstamp { get; set; }
		public string Apttus_Config2__AccountScopeOper__c { get; set; }
		public string Apttus_Config2__Action__c { get; set; }
		public string Apttus_Config2__Field__c { get; set; }
		public string Apttus_Config2__ProductFamilyScopeOper__c { get; set; }
		public string Apttus_Config2__ProductFamilyScope__c { get; set; }
		public string Apttus_Config2__ProductGroupScopeOper__c { get; set; }
		public string Apttus_Config2__ProductGroupScope__c { get; set; }
		public string Apttus_Config2__ProductScopeOper__c { get; set; }
		public string Apttus_Config2__ProductScope__c { get; set; }
		public string APTS_Ext_ID__c { get; set; }
		public string Apttus_Config2__ValueExpression__c { get; set; }
	}
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
