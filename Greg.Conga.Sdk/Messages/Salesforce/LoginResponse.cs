using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class LoginResponse
	{
		/*
			{
				"access_token": "00D7a00000019Pq!ARQAQAlsH.yCFoHQS8z8Sz5qCUxZZf2SpAmXwO9jrqCfSZCNH4iQY5l1L2nkVRP4k36mbVdMLYOY1bmznXhF_G3QRabItxsU",
				"instance_url": "https://egl-apttus--preprod.my.salesforce.com",
				"id": "https://test.salesforce.com/id/00D7a00000019PqEAI/0053X00000AnH5IQAV",
				"token_type": "Bearer",
				"issued_at": "1644510178569",
				"signature": "7UDcUbvrmx9LuHqAhu89mfO5QqDVXNLZfAM7HNGAjuY="
			}
		 */

		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("instance_url")]
		public string InstanceUrl { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		[JsonProperty("issued_at")]
		public string IssuedAt { get; set; }

		[JsonProperty("signature")]
		public string Signature { get; set; }

		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonProperty("error_description")]
		public string ErrorDescription { get; set; }
	}
}
