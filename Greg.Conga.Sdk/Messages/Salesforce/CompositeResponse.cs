using Newtonsoft.Json;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class CompositeResponse : SalesforceResponse
	{

        [JsonProperty(PropertyName = "compositeResponse")]
		public List<CompositeResponseChild> Children { get; set; }
	}
}
