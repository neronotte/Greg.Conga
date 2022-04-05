using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	/// <summary>
	/// The output of a <see cref="CreateRequest"/>.
	/// </summary>
	/// <see cref="https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_sobject_create.htm"/>
	public class CreateResponse : SalesforceResponse
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "success")]
		public bool Success { get; set; }

		[JsonProperty(PropertyName = "errors")]
		public string[] Errors { get; set; }
	}
}
