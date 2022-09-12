using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Conga.Sdk.Messages.Conga.Cart
{
	public class UpdateCartRequest : CongaRequest
	{
		public UpdateCartRequest(string cartId, object cart) : base(HttpMethod.Put, $"/carts/{cartId}?alias=false")
		{
			CartId = cartId;
			Cart = cart;
			HasBody = true;
		}

		public string CartId { get; }

		public object Cart { get; }


		public UpdateCartPrice Price { get; set; } = UpdateCartPrice.Default;
		public UpdateCartRule Rule { get; set; } = UpdateCartRule.Default;



		public override string GetUri(CongaEndpoint endpoint)
		{
			var url = base.GetUri(endpoint);
			url += "&price=" + Price.ToString().ToLowerInvariant();
			url += "&rule=" + Rule.ToString().ToLowerInvariant();
			return url;
		}

		public override string ToSerializedObject()
		{
			return JsonConvert.SerializeObject(Cart, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			});
		}
	}

	public enum UpdateCartPrice
	{
		Default,
		Async,
		Skip
	}

	public enum UpdateCartRule
	{
		Default,
		Async,
		Skip
	}
}
