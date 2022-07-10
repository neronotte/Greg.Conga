using Newtonsoft.Json;
using System;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class SwapRequest : CongaRequest
	{
		public SwapRequest() : base(System.Net.Http.HttpMethod.Post, "/assets/swap")
		{
		}

		[JsonProperty("CartIds")]
		public string CartIds { get; set; }

		[JsonProperty("NewStartDate")]
		public string NewStartDate { get; set; }

		[JsonProperty("assetIds")]
		public string[] AssetIds { get; set; }

		[JsonProperty("ProductIds")]
		public string[] ProductIds { get; set; }
	}
}
