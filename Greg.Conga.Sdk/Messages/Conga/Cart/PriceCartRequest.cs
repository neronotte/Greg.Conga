using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Conga.Sdk.Messages.Conga.Cart
{
    public class PriceCartRequest : CongaRequest
    {
        public PriceCartRequest(string cartId) : base(HttpMethod.Post, $"/carts/{cartId}/price?mode=")
        {
            CartId = cartId;
            Mode = CartPriceRequestMode.Turbo;
        }

        [JsonIgnore]
        public string CartId { get; }

        [JsonIgnore]
        public CartPriceRequestMode Mode { get; set; }

        public override string GetUri(CongaEndpoint endpoint)
        {
            var uri = base.GetUri(endpoint);
            uri += Mode.ToString().ToLowerInvariant();
            return uri;
        }
    }


    public enum CartPriceRequestMode
    {
        Default,

        Turbo
    }
}
