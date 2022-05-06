using Greg.Conga.Sdk.Messages.Conga.QueryModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class CongaQueryRequest : CongaRequest, IHoldConditions, IHoldFilters, IHoldLookups, IHoldChildren
	{
		private readonly string apiName;


		public CongaQueryRequest(string entityName) : base("POST", $"/{entityName}/query")
		{
			if (string.IsNullOrWhiteSpace(entityName))
				throw new ArgumentNullException(nameof(entityName));

			this.apiName = entityName;
			this.ExpressionOperator = FilterOperator.And;
			this.Aggregate = false;
			this.SkipCache = false;
			this.View = "detail";
			this.Expand = true;
			this.CacheStrategy = CacheStrategy.Freshness;
			this.Alias = false;
			this.Conditions = new List<Condition>();
			this.Filters = new List<Filter>();
			this.Children = new List<Child>();
			this.SortOrder = new List<SortCriteria>();
			this.Joins = new List<JoinCondition>();
			this.Lookups = new List<LookupCriteria>();
			this.Page = new Paging{ PageLimit = 5000, PageNumber = 1 };
		}


		/// <summary>
		/// AND, OR
		/// </summary>
		[JsonProperty(PropertyName ="expressionOperator")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FilterOperator ExpressionOperator { get; set; }


		[JsonProperty(PropertyName = "aggregate")]
		public bool Aggregate { get; set; }


		[JsonProperty(PropertyName ="skipCache")]
		public bool SkipCache { get; set; }


		[JsonProperty(PropertyName ="view")]
		public string View { get; set; }


		[JsonProperty(PropertyName = "expand")]
		public bool Expand { get; set; }


		[JsonProperty(PropertyName = "cacheStrategy")]
		[JsonConverter(typeof(StringEnumConverter))]
		public CacheStrategy CacheStrategy { get; set; }


		[JsonProperty(PropertyName = "alias")]
		public bool Alias { get; set; }


		[JsonProperty(PropertyName = "conditions")]
		public List<Condition> Conditions { get; }


		[JsonProperty(PropertyName = "filters")]
		public List<Filter> Filters { get; }


		[JsonProperty(PropertyName = "page")]
		public Paging Page { get; }


		[JsonProperty(PropertyName = "sortOrder")]
		public List<SortCriteria> SortOrder { get; }


		[JsonProperty(PropertyName = "joins")]
		public List<JoinCondition> Joins { get; }


		[JsonProperty(PropertyName = "lookups")]
		public List<LookupCriteria> Lookups { get; }


		[JsonProperty(PropertyName = "children")]
		public List<Child> Children { get; }


		[JsonIgnore]
		[JsonProperty(PropertyName = "aggregateFields")]
		[Obsolete("Da capire come gestire")]
		public object AggregateFields { get; set; }



		public string GetApiName()
		{
			return apiName;
		}


		public SortCriteria AddSort(string field, Order order = Order.Ascending)
		{
			var sort = new SortCriteria(field, order);
			this.SortOrder.Add(sort);
			return sort;
		}


		public JoinCondition Join(string toTable, string fromAttribute, string toAttribute)
		{
			var joinCondition = new JoinCondition(toTable, fromAttribute, toAttribute);
			this.Joins.Add(joinCondition);
			return joinCondition;
		}
	}
}
