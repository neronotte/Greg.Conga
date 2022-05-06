using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public class JoinCondition : IHoldConditions, IHoldFilters
	{
		internal JoinCondition(string toTable, string fromAttribute, string toAttribute)
		{
			if (string.IsNullOrWhiteSpace(toTable))
				throw new ArgumentNullException(nameof(toTable), $"{nameof(toTable)} should not be null or empty!");
			if (string.IsNullOrWhiteSpace(fromAttribute))
				throw new ArgumentNullException(nameof(fromAttribute), $"{nameof(fromAttribute)}  should not be null or empty!");
			if (string.IsNullOrWhiteSpace(toAttribute))
				throw new ArgumentNullException(nameof(toAttribute), $"{nameof(toAttribute)}  should not be null or empty!");

			this.ToTable = toTable;
			this.ToAttribute = toAttribute;
			this.FromAttribute = fromAttribute;

			this.ExpressionOperator = FilterOperator.And;

			this.Conditions = new List<Condition>();
			this.Filters = new List<Filter>();
		}

		/// <summary>
		/// The key on the primary table used in the join (Commonly, Id).
		/// </summary>
		[JsonProperty(PropertyName = "fromAttribute")]
		public string FromAttribute { get; }

		/// <summary>
		/// The foreign key on the joining table.
		/// </summary>
		[JsonProperty(PropertyName = "toAttribute")]
		public string ToAttribute { get; }

		/// <summary>
		/// The fully qualified API name of the table to join.
		/// </summary>
		[JsonProperty(PropertyName = "apiName")]
		public string ToTable { get; }

		/// <summary>
		/// The expression used to combine conditions and filters. (AND, OR)
		/// </summary>
		[JsonProperty(PropertyName = "expressionOperator")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FilterOperator ExpressionOperator { get; set; }

		[JsonProperty(PropertyName = "conditions")]
		public List<Condition> Conditions { get; }


		[JsonProperty(PropertyName = "filters")]
		public List<Filter> Filters { get; }



		public string GetApiName()
		{
			return ToTable;
		}
	}
}
