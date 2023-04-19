using Newtonsoft.Json;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages
{
    public class DynamicObject : Dictionary<string, object>
	{
		public DynamicObject(string type)
		{
			this.Attributes = new DynamicObjectAttributes(type);
		}

		[JsonProperty(PropertyName = "attributes")]
		public DynamicObjectAttributes Attributes { get; }
	}

	public class DynamicObjectAttributes
	{
		public DynamicObjectAttributes(string type)
		{
			Type = type;
		}

		[JsonProperty(PropertyName ="type")]
		public string Type { get; }
	}
}
