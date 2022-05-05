using System;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetProductRulesResponse : CongaRestResponse<GetProductRulesResponse.MyData[]>
	{
		public class MyData
		{
			public string APTS_Ext_ID { get; set; }
			public bool IsBundleContext { get; set; }
			public bool MatchInOptions { get; set; }
			public string LastModifiedById { get; set; }
			public Constraintrulecondition[] ConstraintRuleConditions { get; set; }
			public string UpdateView { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public Constraintruleaction[] ConstraintRuleActions { get; set; }
			public bool MatchInAsset { get; set; }
			public string CreatedById { get; set; }
			public string OwnerId { get; set; }
			public bool Active { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool MatchInPrimaryLines { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string ConditionAssociation { get; set; }
		}

		public class Constraintrulecondition
		{
			public string APTS_Ext_ID { get; set; }
			public bool MatchInOptions { get; set; }
			public string LastModifiedById { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public bool MatchInAsset { get; set; }
			public string ConditionCriteria { get; set; }
			public bool MatchInCartOptions { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public string ProductFieldOperatorB { get; set; }
			public bool IsDeleted { get; set; }
			public string ProductFieldOperatorD { get; set; }
			public bool MatchInLocation { get; set; }
			public float Sequence { get; set; }
			public string ProductScope { get; set; }
			public bool MatchInRelatedLines { get; set; }
			public string ConstraintRuleId { get; set; }
			public string CreatedById { get; set; }
			public string Name { get; set; }
			public string EditCriteria { get; set; }
			public bool MatchInPrimaryLines { get; set; }
			public string ProductFieldOperatorA { get; set; }
			public string ProductFieldOperatorC { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public bool MatchInServiceAssets { get; set; }
		}

		public class Constraintruleaction
		{
			public string APTS_Ext_ID { get; set; }
			public bool MatchInOptions { get; set; }
			public string LastModifiedById { get; set; }
			public string ActionType { get; set; }
			public bool AutoInclude { get; set; }
			public string Id { get; set; }
			public bool RepeatInclusion { get; set; }
			public DateTime CreatedDate { get; set; }
			public bool MatchInAsset { get; set; }
			public bool MatchInCartOptions { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string ProductId { get; set; }
			public bool AutoExclude { get; set; }
			public string CurrencyIsoCode { get; set; }
			public string Message { get; set; }
			public string ActionIntent { get; set; }
			public bool IsDeleted { get; set; }
			public Product Product { get; set; }
			public float Sequence { get; set; }
			public string ProductScope { get; set; }
			public string ConstraintRuleId { get; set; }
			public string CreatedById { get; set; }
			public string Name { get; set; }
			public string EditCriteria { get; set; }
			public bool MatchInPrimaryLines { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string ActionDisposition { get; set; }
		}

		public class Product
		{
			public string APTS_Ext_ID { get; set; }
			public string Icon { get; set; }
			public bool egl_brick_extraproduct { get; set; }
			public float egl_pdr_type { get; set; }
			public bool egl_is_expired { get; set; }
			public string LastModifiedById { get; set; }
			public string egl_generic_id { get; set; }
			public string Id { get; set; }
			public string egl_invoice_frequency { get; set; }
			public string Family { get; set; }
			public DateTime CreatedDate { get; set; }
			public bool egl_cartdetails_visibility { get; set; }
			public string egl_bill_position { get; set; }
			public bool ExcludeFromSitemap { get; set; }
			public bool IsArchived { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string CurrencyIsoCode { get; set; }
			public Pricelist[] PriceLists { get; set; }
			public bool egl_required_residential { get; set; }
			public bool Customizable { get; set; }
			public bool egl_listino_associato { get; set; }
			public bool HasDefaults { get; set; }
			public float Version { get; set; }
			public bool IsDeleted { get; set; }
			public bool HasAttributes { get; set; }
			public bool egl_brick_highlander { get; set; }
			public string ProductType { get; set; }
			public bool egl_privacy_required { get; set; }
			public string RecordTypeId { get; set; }
			public bool ShowTabView { get; set; }
			public string Canali_di_Vendita { get; set; }
			public string CreatedById { get; set; }
			public string Name { get; set; }
			public string Uom { get; set; }
			public string ConfigurationType { get; set; }
			public bool egl_DOI { get; set; }
			public bool Allegato { get; set; }
			public bool egl_isProductClone { get; set; }
			public bool egl_sconto_extra_added { get; set; }
			public bool HasSearchAttributes { get; set; }
			public bool HasOptions { get; set; }
			public bool egl_administrative_cost { get; set; }
			public bool IsActive { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string egl_brick_subtype { get; set; }
			public string egl_brick_description { get; set; }
			public string egl_invoice_label { get; set; }
			public string egl_clusterization { get; set; }
			public string egl_period_criteria { get; set; }
			public float egl_period_delay { get; set; }
			public string APTSENI_Commodity { get; set; }
			public string egl_iva { get; set; }
			public string egl_brick_type { get; set; }
			public DateTime egl_Data_Set_Definitivo { get; set; }
			public string Status { get; set; }
			public string egl_unit_of_measure { get; set; }
			public string egl_accounting_item { get; set; }
			public string egl_period_uom { get; set; }
			public string egl_clawback_flag { get; set; }
			public float egl_period_duration { get; set; }
			public string egl_billingitem_code { get; set; }
			public string egl_Definitivo_Settato_Da { get; set; }
			public string egl_recurrency_type { get; set; }
			public string egl_DOI_Description { get; set; }
			public string egl_invoice_label2 { get; set; }
			public float egl_recurrenc_num { get; set; }
			public string egl_address_type { get; set; }
			public string egl_SKU { get; set; }
			public string StockKeepingUnit { get; set; }
			public string Description { get; set; }
			public DateTime EffectiveDate { get; set; }
			public DateTime ExpirationDate { get; set; }
			public string egl_customer_type { get; set; }
			public string ProductCode { get; set; }
			public string egl_unique_product_code { get; set; }
		}

		public class Pricelist
		{
			public string PriceListId { get; set; }
			public string LastModifiedById { get; set; }
			public string egl_generic_id { get; set; }
			public string Id { get; set; }
			public bool AutoCascadeSellingTerm { get; set; }
			public DateTime CreatedDate { get; set; }
			public string PriceMethod { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsUsageTierModifiable { get; set; }
			public bool HasCriteria { get; set; }
			public bool EnablePriceRamp { get; set; }
			public bool AllowProration { get; set; }
			public bool DisableAssetIntegration { get; set; }
			public float ListPrice { get; set; }
			public string ProductFamily { get; set; }
			public string PriceType { get; set; }
			public string ProductName { get; set; }
			public bool AllocateGroupAdjustment { get; set; }
			public bool RollupPriceToBundle { get; set; }
			public bool EnableAutoRampCreation { get; set; }
			public string ChargeType { get; set; }
			public bool IsDeleted { get; set; }
			public float Sequence { get; set; }
			public bool DisableSyncWithOpportunity { get; set; }
			public bool AllowPriceRampOverlap { get; set; }
			public bool AutoRenew { get; set; }
			public bool IsQuantityReadOnly { get; set; }
			public string CreatedById { get; set; }
			public bool Active { get; set; }
			public string Name { get; set; }
			public bool TaxInclusive { get; set; }
			public bool AutoCascadeQuantity { get; set; }
			public bool AllowManualAdjustment { get; set; }
			public bool EnableCommitment { get; set; }
			public float NumberOfMatrices { get; set; }
			public bool ProductActive { get; set; }
			public bool IsSellingTermReadOnly { get; set; }
			public bool PriceIncludedInBundle { get; set; }
			public bool DisableCostModel { get; set; }
			public bool Taxable { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string egl_Family_Ops { get; set; }
			public string PriceUom { get; set; }
			public string egl_package_code { get; set; }
			public string egl_uom_value { get; set; }
			public string Criteria { get; set; }
			public string egl_package { get; set; }
			public string egl_pricelist_neta { get; set; }
			public string Description { get; set; }
			public string egl_invoice_frequency { get; set; }
			public float egl_percent_value { get; set; }
			public DateTime EffectiveDate { get; set; }
			public DateTime ExpirationDate { get; set; }
			public float DefaultSellingTerm { get; set; }
			public string ProductDescription { get; set; }
			public string APTS_Ext_ID { get; set; }
			public string Frequency { get; set; }
			public string ProductCode { get; set; }
		}
	}
}
