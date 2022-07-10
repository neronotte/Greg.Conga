using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class DescribeRequest : SalesforceRequest
	{
		public DescribeRequest(string objectName) : base(System.Net.Http.HttpMethod.Get, $"/sobjects/{objectName}/describe/")
		{
			ObjectName = objectName;
			HasBody = false;
		}

		[JsonIgnore]
		public string ObjectName { get; }
	}
}
