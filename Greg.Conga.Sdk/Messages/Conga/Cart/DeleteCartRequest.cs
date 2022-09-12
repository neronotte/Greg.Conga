using Newtonsoft.Json;
using System.Net.Http;

namespace Greg.Conga.Sdk.Messages.Conga.Cart
{
	public class DeleteCartRequest : CongaRequest
    {
		public DeleteCartRequest(string cartId) : base(HttpMethod.Delete, $"/carts/{cartId}")
		{
			CartId = cartId;
		}

		[JsonIgnore]
		public string CartId { get; }
	}
}
