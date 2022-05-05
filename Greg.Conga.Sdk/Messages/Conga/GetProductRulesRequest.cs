using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetProductRulesRequest : CongaRequest
	{
		public GetProductRulesRequest(string productId) : base("GET", $"/products/{productId}/rules")
		{
			ProductId = productId;
			HasBody = false;
		}

		[JsonIgnore]
		public string ProductId { get; }
	}
}
