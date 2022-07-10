using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class AddProductToCartRequest : CongaRequest
	{
		public AddProductToCartRequest() : base(System.Net.Http.HttpMethod.Post, "/carts/{CartId}/items")
		{
		}

		[JsonIgnore]
		public string CartId { get; set; }



		public override string ToSerializedObject()
		{
			return base.ToSerializedObject();
		}
	}
}
