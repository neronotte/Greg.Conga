using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class CreateProposalRequest : CongaRequest
	{
		public CreateProposalRequest() : base("POST", "/carts/{CartId}/proposal")
		{
		}

		[JsonIgnore]
		public string CartId { get; set; }


		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
