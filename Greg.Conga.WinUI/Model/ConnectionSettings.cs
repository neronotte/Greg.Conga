using Greg.Conga.Sdk;
using System;
using System.Configuration;

namespace Greg.Conga.WinUI.Model
{
	public class ConnectionSettings
	{
		public string Name { get; set; }

		public bool IsDefault { get; private set; }

		public CongaEndpoint Endpoint { get; set; }

		public CongaCredentials Credentials { get; set; }


		public override string ToString()
		{
			return Name;
		}


		public static ConnectionSettings Default { get; } = GetDefault();

		private static ConnectionSettings GetDefault()
		{
			var endpoint = new CongaEndpoint
			{
				AuthenticationEndpoint = ConfigurationManager.AppSettings["conga.endpoint.AuthenticationEndpoint"],
				AuthenticationClientId = ConfigurationManager.AppSettings["conga.endpoint.AuthenticationClientId"],
				AuthenticationSecret = ConfigurationManager.AppSettings["conga.endpoint.AuthenticationSecret"],
				RestApiRootEndpoint = ConfigurationManager.AppSettings["conga.endpoint.RestApiRootEndpoint"],
				SalesforceApiRootEndpoint = ConfigurationManager.AppSettings["conga.endpoint.SalesforceApiRootEndpoint"],
				Storefront = ConfigurationManager.AppSettings["conga.endpoint.Storefront"],
			};

			var credentials = new CongaCredentials
			{
				Username = ConfigurationManager.AppSettings["conga.credentials.username"],
				Password = ConfigurationManager.AppSettings["conga.credentials.password"]
			};



			var connectionSettings = new ConnectionSettings
			{
				Name = "Default",
				IsDefault = true,
				Endpoint = endpoint,
				Credentials = credentials
			};
			return connectionSettings;
		}
	}
}
