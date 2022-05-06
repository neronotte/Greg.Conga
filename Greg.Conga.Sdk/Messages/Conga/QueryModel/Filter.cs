using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public class Filter : IHoldConditions, IHoldFilters
	{
		private readonly string apiName;

		internal Filter(string apiName)
		{
			this.apiName = apiName;

			this.Conditions = new List<Condition>();
			this.Filters = new List<Filter>();
			this.ExpressionOperator =FilterOperator.And;
		}

		[JsonProperty(PropertyName = "conditions")]
		public List<Condition> Conditions { get; }

		[JsonProperty(PropertyName = "filters")]
		public List<Filter> Filters { get; }

		/// <summary>
		/// AND, OR
		/// </summary>
		[JsonProperty(PropertyName = "expressionOperator")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FilterOperator ExpressionOperator { get; set; }



		public string GetApiName()
		{
			return this.apiName;
		}
	}
}
