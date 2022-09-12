using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;

namespace Greg.Conga.Sdk.Messages.Conga.Asset
{
	public class ChangeAssetRequest : CongaRequest
	{
		public ChangeAssetRequest(string assetId) : base(HttpMethod.Post, $"/assets/{assetId}/change")
		{
			AssetId = assetId;
			HasBody = true;
		}


		internal override void AddAdditionalHeaders(HttpRequestMessage request)
		{
			base.AddAdditionalHeaders(request);

			if (string.IsNullOrWhiteSpace(AccountId)) return;
			request.Headers.Add("x-account", AccountId);
		}






		[JsonIgnore]
		public string AssetId { get; }

		/// <summary>
		/// ID dell'account associato all'asset line item
		/// </summary>
		[JsonIgnore]
		public string AccountId { get; set; }

		[JsonProperty(PropertyName = "ProductAttributeValues")]
		public AssetChangeRequest_ProductAttributeValue[] ProductAttributeValues { get; set; }

		[JsonProperty(PropertyName = "Step")]
		[JsonConverter(typeof(StringEnumConverter))]
		public AssetChangeRequest_Step Step { get; set; }

		[JsonProperty(PropertyName = "SelectedOptions")]
		public AssetChangeRequest_SelectedOptions[] SelectedOptions { get; set; }

		[JsonProperty(PropertyName = "CartId")]
		public string CartId { get; set; }

		[JsonProperty(PropertyName = "CancelledOptions")]
		public string[] CancelledOptions { get; set; }

		[JsonProperty(PropertyName = "AmendedAssets")]
		public IReadOnlyCollection<DynamicObject> AmendedAssets { get; private set; }

		public DynamicObject AddAmendedAsset()
		{
			var temp = new DynamicObject("Apttus_Config2__LineItem__c");

			if (AmendedAssets == null)
			{
				AmendedAssets = new List<DynamicObject>();
			}

			var list = (List<DynamicObject>)AmendedAssets;
			list.AddRange(AmendedAssets);
			list.Add(temp);

			return temp;
		}
	}


#pragma warning disable CA1707 // Identifiers should not contain underscores

	public enum AssetChangeRequest_Step
    {
        [EnumMember(Value = "CHANGE_ASSET")]
        CHANGE_ASSET,

        [EnumMember(Value = "VALIDATE")]
        VALIDATE,

        [EnumMember(Value = "RUN_CONSTRAINTS")]
        RUN_CONSTRAINTS,

        [EnumMember(Value = "REPRICE")]
        REPRICE
    }


    public class AssetChangeRequest_ProductAttributeValue
    {
        [JsonProperty(PropertyName = "AssetId")]
        public string AssetId { get; set; }


        [JsonProperty(PropertyName = "AttributeValueExt3SO")]
        public DynamicObject AttributeValueExt3SO { get; } = new DynamicObject("Apttus_Config2__ProductAttributeValueExt3__c");


        [JsonProperty(PropertyName = "AttributeValueExt2SO")]
        public DynamicObject AttributeValueExt2SO { get; } = new DynamicObject("Apttus_Config2__ProductAttributeValueExt2__c");


        [JsonProperty(PropertyName = "AttributeValueExtSO")]
        public DynamicObject AttributeValueExtSO { get; } = new DynamicObject("Apttus_Config2__ProductAttributeValueExt__c");


        [JsonProperty(PropertyName = "AttributeValueSO")]
        public DynamicObject AttributeValueSO { get; } = new DynamicObject("Apttus_Config2__ProductAttributeValue__c");


        [JsonProperty(PropertyName = "NullFields")]
        public AssetChangeRequest_ProductAttributeValue_NullFields NullFields { get; set; }
    }

    public class AssetChangeRequest_ProductAttributeValue_NullFields
    {
        [JsonProperty(PropertyName = "Apttus_Config2__ProductAttributeValue__c")]
        public string[] Apttus_Config2__ProductAttributeValue__c { get; set; } = Array.Empty<string>();

        [JsonProperty(PropertyName = "Apttus_Config2__ProductAttributeValueExt__c")]
        public string[] Apttus_Config2__ProductAttributeValueExt__c { get; set; } = Array.Empty<string>();

        [JsonProperty(PropertyName = "Apttus_Config2__ProductAttributeValueExt2__c")]
        public string[] Apttus_Config2__ProductAttributeValueExt2__c { get; set; } = Array.Empty<string>();

        [JsonProperty(PropertyName = "Apttus_Config2__ProductAttributeValueExt3__c")]
        public string[] Apttus_Config2__ProductAttributeValueExt3__c { get; set; } = Array.Empty<string>();
    }


    public class AssetChangeRequest_SelectedOptions
    {
        public DateTime? StartDate { get; set; }

        public int? SellingTerm { get; set; }

        public int? Quantity { get; set; }

        public string[] CustomFields { get; set; } = Array.Empty<string>();

        public DynamicObject CustomData { get; } = new DynamicObject("Apttus_Config2__LineItem__c");

        public string ComponentProductId { get; set; }
        public string ComponentId { get; set; }

        public IReadOnlyCollection<DynamicObject> AttributeValues { get; private set; } = new List<DynamicObject>();

        public DynamicObject AddAttributeValue()
        {
            var temp = new DynamicObject("Apttus_Config2__ProductAttributeValue__c");

            var list = (List<DynamicObject>)AttributeValues;
            list.AddRange(AttributeValues);
            list.Add(temp);

            return temp;
        }


    }


#pragma warning restore CA1707 // Identifiers should not contain underscores
}
