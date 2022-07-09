using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetProductRulesRequest : CongaRequest
	{
		public GetProductRulesRequest(string productId) : base(System.Net.Http.HttpMethod.Get, $"/products/{productId}/rules")
		{
			ProductId = productId;
			HasBody = false;
		}

		[JsonIgnore]
		public string ProductId { get; }
	}
}
