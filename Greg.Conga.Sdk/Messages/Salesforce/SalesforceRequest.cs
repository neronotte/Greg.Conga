namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public abstract class SalesforceRequest : BaseRequest
	{
		public SalesforceRequest(string method, string urlPart) : base(method, urlPart)
		{
		}



		public override string GetUri(CongaEndpoint endpoint)
		{
			var firstPart = endpoint.SalesforceApiRootEndpoint.TrimEnd('/');
			var urlPart = UrlPart.TrimStart('/');
			return firstPart + "/" + urlPart;
		}
	}
}
