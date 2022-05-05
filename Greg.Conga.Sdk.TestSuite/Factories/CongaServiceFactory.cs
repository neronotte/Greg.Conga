using Greg.Conga.Sdk.TestSuite.Factory;

namespace Greg.Conga.Sdk.TestSuite.Factories
{
	public static class CongaServiceFactory
	{
		public static ICongaService GetNewService()
		{
			var endpoint = CongaEndpointFactory.FromFile("C:\\temp\\conga.endpoint.preprod.txt");
			var credentials = CongaCredentialsFactory.FromFile("C:\\temp\\conga.credentials.preprod.txt");

			var congaService = new CongaService(endpoint);
			congaService.Authenticate(credentials);
			return congaService;
		}
	}
}
