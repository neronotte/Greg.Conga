using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class QueryResponse<T> : SalesforceResponse
	{
		[JsonProperty("totalSize")]
		public int RecordCount { get; set; }

		[JsonProperty("nextRecordsUrl")]
		public string NextRecordsUrl { get; set; }

		[JsonProperty("records")]
		public T[] Records { get; set; }


		public QueryRequest GetNextPage()
		{
			return QueryRequest.FromResponse(this);
		}
	}
}
