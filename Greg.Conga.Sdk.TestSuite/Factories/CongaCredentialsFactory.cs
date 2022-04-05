using Newtonsoft.Json;
using System.IO;

namespace Greg.Conga.Sdk.TestSuite.Factory
{
	public static class CongaCredentialsFactory
	{
		public static CongaCredentials FromFile(string fileName)
		{
			var text = File.ReadAllText(fileName);
			var result = JsonConvert.DeserializeObject<CongaCredentials>(text);
			return result;
		}
	}
}
