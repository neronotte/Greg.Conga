using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class SalesforceResponse : BaseResponse
	{
		[JsonProperty("errorCode")]
		public string ErrorCode { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}
