using Newtonsoft.Json;
using System.Net.Http;

namespace Greg.Conga.Sdk.Messages.Conga.Cart
{
    public class CreateCartRequest : CongaRequest
    {
        public CreateCartRequest(object cart) : base(HttpMethod.Post, "/carts?alias=false")
        {
            Cart = cart;
        }



        internal override void AddAdditionalHeaders(HttpRequestMessage request)
        {
            base.AddAdditionalHeaders(request);

            if (string.IsNullOrWhiteSpace(AccountId)) return;
            request.Headers.Add("x-account", AccountId);
        }

        [JsonIgnore]
        public string AccountId { get; set; }

        [JsonIgnore]
        public object Cart { get; set; }



		public override string ToSerializedObject()
		{
			return JsonConvert.SerializeObject(Cart, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			});
		}
	}
}
