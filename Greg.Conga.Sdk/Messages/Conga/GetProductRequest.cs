using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetProductRequest : CongaRequest
	{
		public GetProductRequest(string productId) : base(System.Net.Http.HttpMethod.Get, $"/products/{productId}")
		{
			ProductId = productId;
			HasBody = false;
		}

		[JsonIgnore]
		public string ProductId { get; }
	}
}
