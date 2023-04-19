using Newtonsoft.Json;
using System.Net.Http;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class CompositeRequestChild
	{
		[JsonProperty(PropertyName = "method")]
		public string Method { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "referenceId")]
		public string ReferenceId { get; set; }

		[JsonProperty(PropertyName = "body", NullValueHandling = NullValueHandling.Ignore)]
		public object Body { get; set; }

		[JsonProperty(PropertyName = "httpHeaders", NullValueHandling = NullValueHandling.Ignore)]
		public object HttpHeaders { get; set; }
	}
}
