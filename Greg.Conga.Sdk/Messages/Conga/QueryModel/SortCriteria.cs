using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public class SortCriteria
	{
		internal SortCriteria(string field, Order order)
		{
			if (string.IsNullOrWhiteSpace(field))
				throw new ArgumentNullException(nameof(field), "Field should not be null or empty!");

			this.Field = field;
			this.Direction = order;
		}

		[JsonProperty(PropertyName = "field")]
		public string Field { get; }

		/// <summary>
		/// ASC, DESC
		/// </summary>
		[JsonProperty(PropertyName = "direction")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Order Direction { get; }
	}
}
