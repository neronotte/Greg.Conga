using Newtonsoft.Json;
using System.IO;

namespace Greg.Conga.Sdk.TestSuite.Factory
{
	public static class CongaEndpointFactory
	{
		public static CongaEndpoint FromFile(string fileName)
		{
			var text = File.ReadAllText(fileName);
			var result = JsonConvert.DeserializeObject<CongaEndpoint>(text);
			return result;
		}
	}
}
