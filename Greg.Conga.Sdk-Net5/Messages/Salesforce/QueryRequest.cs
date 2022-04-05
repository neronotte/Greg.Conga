namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class QueryRequest : SalesforceRequest
	{
		public QueryRequest() : base("GET", "/query?q={query}")
		{
			HasBody = false;
		}
		public QueryRequest(string query) : this()
		{
			Query = query;
		}


		public string Query { get; set; }


		public override string GetUri(CongaEndpoint endpoint)
		{
			var uri = base.GetUri(endpoint);
			uri = uri.Replace("{query}", Query);
			return uri;
		}
	}
}
