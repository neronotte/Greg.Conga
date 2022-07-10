using Greg.Conga.Sdk.Converters;
using Newtonsoft.Json;
using System;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class TerminateRequest : CongaRequest
	{
		public TerminateRequest(string cartId) : base(System.Net.Http.HttpMethod.Post, $"/assets/{cartId}/terminate")
		{
			this.CartId = cartId;
		}

		[JsonIgnore]
		public string CartId { get; }

		[JsonProperty("CancelDate", ItemConverterType = typeof(DateTimeToStringConverter), ItemConverterParameters = new[] { "yyyy-MM-dd" })]
		public DateTime CancelDate { get; }

		[JsonProperty("assetIds")]
		public string[] AssetIds { get; set; }
	}
}
