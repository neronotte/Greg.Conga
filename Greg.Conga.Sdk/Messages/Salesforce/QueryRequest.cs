using System;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class QueryRequest : SalesforceRequest
	{
		internal static QueryRequest FromResponse<T>(QueryResponse<T> response)
		{
			if (string.IsNullOrWhiteSpace(response.NextRecordsUrl)) return null;

			var startIndex = response.NextRecordsUrl.IndexOf("/query", StringComparison.OrdinalIgnoreCase);
			var urlPart = response.NextRecordsUrl.Substring(startIndex);

			return new QueryRequest()
			{
				UrlPart = urlPart
			};
		}


		public QueryRequest() : base(System.Net.Http.HttpMethod.Get, "/query?q={query}")
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
