namespace Greg.Conga.Sdk
{
	public class CongaEndpoint
	{
		public string AuthenticationEndpoint { get; set; }
		public string AuthenticationClientId { get; set; }
		public string AuthenticationSecret { get; set; }
		public string RestApiRootEndpoint { get; set; }
		public string SalesforceApiRootEndpoint { get; set; }
		public string Storefront { get; set; }
	}
}
