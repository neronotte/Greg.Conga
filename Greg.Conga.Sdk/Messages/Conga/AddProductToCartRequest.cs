using Newtonsoft.Json;
using System.Security.Permissions;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class AddProductToCartRequest : CongaRequest
	{
		public AddProductToCartRequest(string cartId) : base(System.Net.Http.HttpMethod.Post, $"/carts/{cartId}/items")
		{
			this.CartId = cartId;
		}

		[JsonIgnore]
		public string CartId { get;  }

		public object LineItem { get; set; }

		public object ProductAttributes { get; set; }

		public string ProductId	{ get; set; }
		public int? Quantity { get; set; }
		public string FavoriteId { get; set; }



		public override string ToSerializedObject()
		{
			return base.ToSerializedObject();
		}
	}
}
