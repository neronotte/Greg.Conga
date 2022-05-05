using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetProductRequest : CongaRequest
	{
		public GetProductRequest(string productId) : base("GET", $"/products/{productId}")
		{
			ProductId = productId;
			HasBody = false;
		}

		[JsonIgnore]
		public string ProductId { get; }
	}
}
