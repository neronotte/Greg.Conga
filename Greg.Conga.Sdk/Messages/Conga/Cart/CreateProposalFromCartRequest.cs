using Newtonsoft.Json;
using System.Net.Http;

namespace Greg.Conga.Sdk.Messages.Conga.Cart
{
	public class CreateProposalFromCartRequest : CongaRequest
	{
		public CreateProposalFromCartRequest(string cartId, object proposal) : base(HttpMethod.Post, $"/carts/{cartId}/proposal")
		{
			Proposal = proposal;
		}


		[JsonIgnore]
		public string AccountId { get; set; }

		[JsonIgnore]
		public object Proposal { get; set; }



		public override string ToSerializedObject()
		{
			return JsonConvert.SerializeObject(Proposal, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			});
		}
	}

}
