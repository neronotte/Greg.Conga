using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class AddProductToCartRequest : CongaRequest
	{
		public AddProductToCartRequest() : base("POST", "/carts/{CartId}/items")
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
