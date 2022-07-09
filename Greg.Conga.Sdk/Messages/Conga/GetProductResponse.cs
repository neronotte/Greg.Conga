using System;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetProductResponse : CongaRestResponse<GetProductResponse.MyData>
	{

#pragma warning disable CA1707 // Identifiers should not contain underscores



		public class MyData
		{
			public string Icon { get; set; }
			public float egl_pdr_type { get; set; }
			public string LastModifiedById { get; set; }
			public string egl_invoice_frequency { get; set; }
			public string Family { get; set; }
			public bool egl_cartdetails_visibility { get; set; }
			public string egl_bill_position { get; set; }
			public string egl_category_icon_sellpoint2 { get; set; }
			public bool IsArchived { get; set; }
			public DateTime SystemModstamp { get; set; }
			public Pricelist[] PriceLists { get; set; }
			public bool egl_required_residential { get; set; }
			public bool Customizable { get; set; }
			public bool egl_listino_associato { get; set; }
			public Attributegroup[] AttributeGroups { get; set; }
			public bool HasAttributes { get; set; }
			public string egl_Siebel_Name { get; set; }
			public string egl_highlight_desc { get; set; }
			public bool egl_privacy_required { get; set; }
			public string APTSENI_Commodity { get; set; }
			public string RecordTypeId { get; set; }
			public string egl_sellingpoint1_icon { get; set; }
			public bool ShowTabView { get; set; }
			public string Canali_di_Vendita { get; set; }
			public Productgroup[] ProductGroups { get; set; }
			public bool egl_isProductClone { get; set; }
			public bool IsActive { get; set; }
			public string egl_sellingpoint2_desc { get; set; }
			public string APTS_Ext_ID { get; set; }
			public string egl_sii_product_code { get; set; }
			public bool egl_brick_extraproduct { get; set; }
			public bool egl_is_expired { get; set; }
			public string Status { get; set; }
			public string egl_commodity_pricelist { get; set; }
			public string egl_generic_id { get; set; }
			public string Id { get; set; }
			public string egl_shortdescription { get; set; }
			public DateTime CreatedDate { get; set; }
			public bool ExcludeFromSitemap { get; set; }
			public string CurrencyIsoCode { get; set; }
			public Optiongroup[] OptionGroups { get; set; }
			public Productattributematrixview[] ProductAttributeMatrixViews { get; set; }
			public bool HasDefaults { get; set; }
			public string ProductCode { get; set; }
			public float Version { get; set; }
			public bool IsDeleted { get; set; }
			public bool egl_brick_highlander { get; set; }
			public string ProductType { get; set; }
			public string egl_sellingpoint2_icon { get; set; }
			public string egl_unique_product_code { get; set; }
			public DateTime EffectiveDate { get; set; }
			public string CreatedById { get; set; }
			public string egl_category_icon_sellpoint1 { get; set; }
			public string IconId { get; set; }
			public string Name { get; set; }
			public string egl_tou_distr { get; set; }
			public string Uom { get; set; }
			public string ConfigurationType { get; set; }
			public bool egl_DOI { get; set; }
			public bool Allegato { get; set; }
			public bool egl_sconto_extra_added { get; set; }
			public bool HasSearchAttributes { get; set; }
			public bool HasOptions { get; set; }
			public bool egl_administrative_cost { get; set; }
			public string egl_Family_OPS { get; set; }
			public DateTime ExpirationDate { get; set; }
			public string egl_sellingpoint1_desc { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Pricelist
		{
			public string PriceListId { get; set; }
			public string LastModifiedById { get; set; }
			public string egl_invoice_frequency { get; set; }
			public string egl_Family_Ops { get; set; }
			public DateTime SystemModstamp { get; set; }
			public bool IsUsageTierModifiable { get; set; }
			public bool EnablePriceRamp { get; set; }
			public bool AllowProration { get; set; }
			public bool DisableAssetIntegration { get; set; }
			public float ListPrice { get; set; }
			public string ProductFamily { get; set; }
			public string PriceType { get; set; }
			public bool AllocateGroupAdjustment { get; set; }
			public bool EnableAutoRampCreation { get; set; }
			public string ChargeType { get; set; }
			public bool DisableSyncWithOpportunity { get; set; }
			public bool AutoRenew { get; set; }
			public string egl_package_code { get; set; }
			public bool IsQuantityReadOnly { get; set; }
			public bool Active { get; set; }
			public bool EnableCommitment { get; set; }
			public float NumberOfMatrices { get; set; }
			public bool ProductActive { get; set; }
			public bool IsSellingTermReadOnly { get; set; }
			public string egl_generic_id { get; set; }
			public string Id { get; set; }
			public bool AutoCascadeSellingTerm { get; set; }
			public DateTime CreatedDate { get; set; }
			public string PriceMethod { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool HasCriteria { get; set; }
			public string ProductName { get; set; }
			public bool RollupPriceToBundle { get; set; }
			public bool IsDeleted { get; set; }
			public bool AllowPriceRampOverlap { get; set; }
			public string Criteria { get; set; }
			public string egl_package { get; set; }
			public string CreatedById { get; set; }
			public string Name { get; set; }
			public bool TaxInclusive { get; set; }
			public bool AutoCascadeQuantity { get; set; }
			public bool AllowManualAdjustment { get; set; }
			public string egl_pricelist_neta { get; set; }
			public bool PriceIncludedInBundle { get; set; }
			public string ProductCode { get; set; }
			public bool DisableCostModel { get; set; }
			public bool Taxable { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Attributegroup
		{
			public string LastModifiedById { get; set; }
			public float Sequence { get; set; }
			public string AttributeGroupId { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public string CreatedById { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public Attributegroup1 AttributeGroup { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Attributegroup1
		{
			public string APTS_Ext_ID { get; set; }
			public string LastModifiedById { get; set; }
			public string Id { get; set; }
			public string BusinessObject { get; set; }
			public DateTime CreatedDate { get; set; }
			public bool ThreeColumnAttributeDisplay { get; set; }
			public string CreatedById { get; set; }
			public string OwnerId { get; set; }
			public AttributeObject[] Attributes { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public bool TwoColumnAttributeDisplay { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string Description { get; set; }
		}

		public class AttributeObject
		{
			public string APTS_Ext_ID { get; set; }
			public string LastModifiedById { get; set; }
			public float Sequence { get; set; }
			public string Id { get; set; }
			public string AttributeGroupId { get; set; }
			public bool IsExtension { get; set; }
			public DateTime CreatedDate { get; set; }
			public string CreatedById { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsHidden { get; set; }
			public string Field { get; set; }
			public bool IsPrimary { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public bool IsReadOnly { get; set; }


			public override string ToString()
			{
				return $"{Field} ({Name}, {Id})";
			}
		}

		public class Productgroup
		{
			public string LastModifiedById { get; set; }
			public float Sequence { get; set; }
			public string Id { get; set; }
			public string ProductGroupId { get; set; }
			public DateTime CreatedDate { get; set; }
			public string CreatedById { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Optiongroup
		{
			public string LastModifiedById { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public string OptionGroupId { get; set; }
			public bool IsLeaf { get; set; }
			public float Level { get; set; }
			public bool IsPicklist { get; set; }
			public DateTime SystemModstamp { get; set; }
			public float Right { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public string RootOptionGroupId { get; set; }
			public bool IsHidden { get; set; }
			public float Left { get; set; }
			public bool CascadeGroupChanges { get; set; }
			public string ContentType { get; set; }
			public bool IsDeleted { get; set; }
			public float RootSequence { get; set; }
			public float Sequence { get; set; }
			public float MaxOptions { get; set; }
			public float MinOptions { get; set; }
			public string CreatedById { get; set; }
			public string egl_option_group { get; set; }
			public string Name { get; set; }
			public Optiongroup1 OptionGroup { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string ModifiableType { get; set; }
			public OptionObject[] Options { get; set; }
		}

		public class Optiongroup1
		{
			public string LastModifiedById { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public string IsLeaf { get; set; }
			public bool HideAllSearchFilters { get; set; }
			public float Level { get; set; }
			public bool IsPicklist { get; set; }
			public DateTime SystemModstamp { get; set; }
			public float Right { get; set; }
			public bool ExpandedByDefault { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsHidden { get; set; }
			public float Left { get; set; }
			public string HierarchyId { get; set; }
			public bool IsDeleted { get; set; }
			public bool Modifiable { get; set; }
			public float ProductCount { get; set; }
			public float MaxOptions { get; set; }
			public bool DefaultSearchCategory { get; set; }
			public float MinOptions { get; set; }
			public string Label { get; set; }
			public string CreatedById { get; set; }
			public string Name { get; set; }
			public bool IncludeInTotalsView { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string APTS_Ext_ID { get; set; }
		}

		public class OptionObject
		{
			public string LastModifiedById { get; set; }
			public string egl_product_recordtype { get; set; }
			public string Id { get; set; }
			public Productoptiongroup ProductOptionGroup { get; set; }
			public string RelationshipType { get; set; }
			public float MaxQuantity { get; set; }
			public float DefaultQuantity { get; set; }
			public DateTime CreatedDate { get; set; }
			public float MinQuantity { get; set; }
			public string ComponentProductId { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string CurrencyIsoCode { get; set; }
			public string ProductOptionGroupId { get; set; }
			public bool AutoUpdateQuantity { get; set; }
			public bool Required { get; set; }
			public bool IsDeleted { get; set; }
			public bool Modifiable { get; set; }
			public bool AllowCloning { get; set; }
			public float Sequence { get; set; }
			public bool Default { get; set; }
			public string egl_period_enddate { get; set; }
			public string ParentProductId { get; set; }
			public string CreatedById { get; set; }
			public string OwnerId { get; set; }
			public string egl_Id_Generico_CPQ { get; set; }
			public string Name { get; set; }
			public string egl_period_startdate { get; set; }
			public bool egl_isProductClone { get; set; }
			public Componentproduct ComponentProduct { get; set; }
			public string ConfigType { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string egl_brick_code { get; set; }
		}

		public class Productoptiongroup
		{
			public string LastModifiedById { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public string OptionGroupId { get; set; }
			public bool IsLeaf { get; set; }
			public float Level { get; set; }
			public bool IsPicklist { get; set; }
			public DateTime SystemModstamp { get; set; }
			public float Right { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public string RootOptionGroupId { get; set; }
			public bool IsHidden { get; set; }
			public float Left { get; set; }
			public bool CascadeGroupChanges { get; set; }
			public string ContentType { get; set; }
			public bool IsDeleted { get; set; }
			public float RootSequence { get; set; }
			public float Sequence { get; set; }
			public float MaxOptions { get; set; }
			public float MinOptions { get; set; }
			public string CreatedById { get; set; }
			public string egl_option_group { get; set; }
			public string Name { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string ModifiableType { get; set; }
		}

		public class Componentproduct
		{
			public string Icon { get; set; }
			public float egl_pdr_type { get; set; }
			public string LastModifiedById { get; set; }
			public string egl_invoice_frequency { get; set; }
			public bool egl_cartdetails_visibility { get; set; }
			public string egl_bill_position { get; set; }
			public bool IsArchived { get; set; }
			public DateTime SystemModstamp { get; set; }
			public bool egl_required_residential { get; set; }
			public bool Customizable { get; set; }
			public bool egl_listino_associato { get; set; }
			public bool HasAttributes { get; set; }
			public bool egl_privacy_required { get; set; }
			public string egl_tag_prodotto { get; set; }
			public string RecordTypeId { get; set; }
			public bool ShowTabView { get; set; }
			public string Canali_di_Vendita { get; set; }
			public bool egl_isProductClone { get; set; }
			public DateTime egl_Data_Set_Definitivo { get; set; }
			public bool IsActive { get; set; }
			public bool egl_brick_extraproduct { get; set; }
			public bool egl_is_expired { get; set; }
			public string Status { get; set; }
			public string egl_generic_id { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public bool ExcludeFromSitemap { get; set; }
			public string egl_Short_Description { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool HasDefaults { get; set; }
			public string ProductCode { get; set; }
			public float Version { get; set; }
			public bool IsDeleted { get; set; }
			public bool egl_brick_highlander { get; set; }
			public string ProductType { get; set; }
			public string egl_unique_product_code { get; set; }
			public string CreatedById { get; set; }
			public string Name { get; set; }
			public string egl_tou_distr { get; set; }
			public string Uom { get; set; }
			public string ConfigurationType { get; set; }
			public bool egl_DOI { get; set; }
			public bool Allegato { get; set; }
			public string Product_Class { get; set; }
			public string egl_Definitivo_Settato_Da { get; set; }
			public bool egl_sconto_extra_added { get; set; }
			public bool HasSearchAttributes { get; set; }
			public bool HasOptions { get; set; }
			public bool egl_administrative_cost { get; set; }
			public DateTime ExpirationDate { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string egl_hourly_plan { get; set; }
			public string egl_brick_subtype { get; set; }
			public string egl_brick_description { get; set; }
			public string egl_invoice_label { get; set; }
			public string egl_clusterization { get; set; }
			public Pricelist1[] PriceLists { get; set; }
			public string egl_period_criteria { get; set; }
			public float egl_period_delay { get; set; }
			public string APTSENI_Commodity { get; set; }
			public string egl_iva { get; set; }
			public string egl_brick_type { get; set; }
			public string egl_unit_of_measure { get; set; }
			public string egl_accounting_item { get; set; }
			public string egl_period_uom { get; set; }
			public string egl_clawback_flag { get; set; }
			public float egl_period_duration { get; set; }
			public string egl_billingitem_code { get; set; }
			public string egl_recurrency_type { get; set; }
			public Productgroup1[] ProductGroups { get; set; }
			public string egl_DOI_Description { get; set; }
			public string APTS_Ext_ID { get; set; }
			public float egl_recurrenc_num { get; set; }
			public string Family { get; set; }
			public Attributegroup2[] AttributeGroups { get; set; }
		}

		public class Pricelist1
		{
			public string PriceListId { get; set; }
			public string LastModifiedById { get; set; }
			public string egl_Family_Ops { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string PriceUom { get; set; }
			public bool IsUsageTierModifiable { get; set; }
			public bool EnablePriceRamp { get; set; }
			public bool AllowProration { get; set; }
			public bool DisableAssetIntegration { get; set; }
			public float ListPrice { get; set; }
			public string PriceType { get; set; }
			public bool AllocateGroupAdjustment { get; set; }
			public bool EnableAutoRampCreation { get; set; }
			public string ChargeType { get; set; }
			public bool DisableSyncWithOpportunity { get; set; }
			public bool AutoRenew { get; set; }
			public string egl_package_code { get; set; }
			public bool IsQuantityReadOnly { get; set; }
			public bool Active { get; set; }
			public bool EnableCommitment { get; set; }
			public float NumberOfMatrices { get; set; }
			public bool ProductActive { get; set; }
			public bool IsSellingTermReadOnly { get; set; }
			public string egl_uom_value { get; set; }
			public string egl_generic_id { get; set; }
			public string Id { get; set; }
			public bool AutoCascadeSellingTerm { get; set; }
			public DateTime CreatedDate { get; set; }
			public string PriceMethod { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool HasCriteria { get; set; }
			public string ProductName { get; set; }
			public bool RollupPriceToBundle { get; set; }
			public bool IsDeleted { get; set; }
			public bool AllowPriceRampOverlap { get; set; }
			public string Criteria { get; set; }
			public string egl_package { get; set; }
			public string CreatedById { get; set; }
			public string Name { get; set; }
			public bool TaxInclusive { get; set; }
			public bool AutoCascadeQuantity { get; set; }
			public bool AllowManualAdjustment { get; set; }
			public string egl_pricelist_neta { get; set; }
			public bool PriceIncludedInBundle { get; set; }
			public bool DisableCostModel { get; set; }
			public bool Taxable { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public string Description { get; set; }
			public string egl_invoice_frequency { get; set; }
			public float egl_percent_value { get; set; }
			public DateTime EffectiveDate { get; set; }
			public DateTime ExpirationDate { get; set; }
			public string ProductFamily { get; set; }
			public float Sequence { get; set; }
		}

		public class Productgroup1
		{
			public string APTS_Ext_ID { get; set; }
			public string LastModifiedById { get; set; }
			public float Sequence { get; set; }
			public string Id { get; set; }
			public string ProductGroupId { get; set; }
			public DateTime CreatedDate { get; set; }
			public string CreatedById { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Attributegroup2
		{
			public string APTS_Ext_ID { get; set; }
			public string LastModifiedById { get; set; }
			public float Sequence { get; set; }
			public string AttributeGroupId { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public string CreatedById { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public Attributegroup3 AttributeGroup { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Attributegroup3
		{
			public string APTS_Ext_ID { get; set; }
			public string LastModifiedById { get; set; }
			public string Id { get; set; }
			public string BusinessObject { get; set; }
			public DateTime CreatedDate { get; set; }
			public bool ThreeColumnAttributeDisplay { get; set; }
			public string CreatedById { get; set; }
			public string OwnerId { get; set; }
			public Attribute1[] Attributes { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public bool TwoColumnAttributeDisplay { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Attribute1
		{
			public string APTS_Ext_ID { get; set; }
			public string LastModifiedById { get; set; }
			public float Sequence { get; set; }
			public string Id { get; set; }
			public string AttributeGroupId { get; set; }
			public bool IsExtension { get; set; }
			public DateTime CreatedDate { get; set; }
			public string CreatedById { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string CurrencyIsoCode { get; set; }
			public bool IsHidden { get; set; }
			public string Field { get; set; }
			public bool IsPrimary { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
			public bool IsReadOnly { get; set; }
		}

		public class Productattributematrixview
		{
			public string LastModifiedById { get; set; }
			public string Id { get; set; }
			public DateTime CreatedDate { get; set; }
			public string Columns { get; set; }
			public string CreatedById { get; set; }
			public string OwnerId { get; set; }
			public Attributevaluematrix AttributeValueMatrix { get; set; }
			public bool Active { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string Hash { get; set; }
			public string ProductId { get; set; }
			public string CurrencyIsoCode { get; set; }
			public string ProductAttributeScope { get; set; }
			public string Keys { get; set; }
			public string AttributeValueMatrixId { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

		public class Attributevaluematrix
		{
			public string APTS_Ext_ID { get; set; }
			public string ApplicationType { get; set; }
			public string LastModifiedById { get; set; }
			public string AccountScope { get; set; }
			public string Id { get; set; }
			public bool TreatNullAsWildcard { get; set; }
			public string ProductScope { get; set; }
			public string DefaultProductAttributeScopeId { get; set; }
			public DateTime CreatedDate { get; set; }
			public string ProductFamilyScope { get; set; }
			public string ProductScopeOper { get; set; }
			public string CreatedById { get; set; }
			public string OwnerId { get; set; }
			public bool Active { get; set; }
			public string ProductGroupScope { get; set; }
			public DateTime SystemModstamp { get; set; }
			public string Name { get; set; }
			public string CurrencyIsoCode { get; set; }
			public string ProductGroupScopeOper { get; set; }
			public string AccountScopeOper { get; set; }
			public string ProductFamilyScopeOper { get; set; }
			public bool IsDeleted { get; set; }
			public DateTime LastModifiedDate { get; set; }
		}

#pragma warning restore CA1707 // Identifiers should not contain underscores
	}
}
