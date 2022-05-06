using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public class Condition
	{
		internal Condition()
		{
		}

		[JsonProperty(PropertyName = "field")]
		public string Field { get; set; }

		[JsonProperty(PropertyName = "filterOperator")]
		[JsonConverter(typeof(StringEnumConverter))]
		public ConditionOperator FilterOperator { get; set; }

		[JsonProperty(PropertyName = "val")]
		public object Val { get; set; }

		[JsonProperty(PropertyName = "value")]
		public object Value { get; set; }

		[JsonProperty(PropertyName = "apiName")]
		public string ApiName { get; set; }
	}
}
