using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class QueryResponse : SalesforceResponse
	{
		[JsonProperty("totalSize")]
		public int RecordCount { get; set; }

		[JsonProperty("records")]
		public DynamicEntity[] Records { get; set; }
	}
}
