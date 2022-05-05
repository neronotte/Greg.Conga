using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class CongaQueryRequest : CongaRequest
	{
		public CongaQueryRequest(string entityName) : base("POST", $"/{entityName}/query")
		{
			EntityName = entityName;
			this.ExpressionOperator = "AND";
			this.Aggregate = false;
			this.SkipCache = false;
			this.View = "detail";
			this.Expand = true;
			this.CacheStrategy = "freshness";
			this.Alias = false;
			this.Conditions = new List<Condition>();
			this.Filters = new List<Filter>();
			this.Children = new List<Child>();
			this.Page = new Paging{ PageLimit = 5000, PageNumber = 1 };
		}

		[JsonIgnore]
		public string EntityName { get; }


		/// <summary>
		/// AND, OR
		/// </summary>
		[JsonProperty(PropertyName ="expressionOperator")]
		public string ExpressionOperator { get; set; }


		[JsonProperty(PropertyName = "aggregate")]
		public bool Aggregate { get; set; }


		[JsonProperty(PropertyName ="skipCache")]
		public bool SkipCache { get; set; }


		[JsonProperty(PropertyName ="view")]
		public string View { get; set; }


		[JsonProperty(PropertyName = "expand")]
		public bool Expand { get; set; }


		[JsonProperty(PropertyName = "cacheStrategy")]
		public string CacheStrategy { get; set; }


		[JsonProperty(PropertyName = "alias")]
		public bool Alias { get; set; }


		[JsonProperty(PropertyName = "conditions")]
		public List<Condition> Conditions { get; }


		[JsonProperty(PropertyName = "filters")]
		public List<Filter> Filters { get; }


		[JsonProperty(PropertyName = "page")]
		public Paging Page { get; }


		[JsonIgnore]
		[JsonProperty(PropertyName = "sortOrder")]
		[Obsolete("Da capire come gestire")]
		public object SortOrder { get; set; }


		[JsonIgnore]
		[JsonProperty(PropertyName = "joins")]
		[Obsolete("Da capire come gestire")]
		public object Joins { get; set; }


		[JsonIgnore]
		[JsonProperty(PropertyName = "lookups")]
		[Obsolete("Da capire come gestire")]
		public object Lookups { get; set; }


		[JsonProperty(PropertyName = "children")]
		public List<Child> Children { get; }


		[JsonIgnore]
		[JsonProperty(PropertyName = "aggregateFields")]
		[Obsolete("Da capire come gestire")]
		public object AggregateFields { get; set; }




		public class Filter 
		{
			public Filter()
			{
				this.Conditions = new List<Condition>();
				this.Filters = new List<Filter>();
			}

			[JsonProperty(PropertyName = "conditions")]
			public List<Condition> Conditions { get; }

			[JsonProperty(PropertyName = "filters")]
			public List<Filter> Filters { get; }

			/// <summary>
			/// AND, OR
			/// </summary>
			[JsonProperty(PropertyName = "expressionOperator")]
			public string ExpressionOperator { get; set; }

			[JsonProperty(PropertyName = "apiName")]
			public string ApiName { get; set; }



			public Condition AddCondition(string field, string filterOperator, object val, object value, string apiName = null)
			{
				if (apiName == null) apiName = ApiName;

				var condition = new Condition
				{
					Field = field,
					FilterOperator = filterOperator,
					Val = val,
					Value = value,
					ApiName = apiName
				};

				this.Conditions.Add(condition);
				return condition;
			}

			public Filter AddFilter(string expressionOperator, string apiName = null)
			{
				if (apiName == null) apiName = ApiName; 

				var filter = new Filter
				{
					ExpressionOperator = expressionOperator,
					ApiName = apiName
				};

				this.Filters.Add(filter);
				return filter;
			}
		}


		public class Condition
		{
			[JsonProperty(PropertyName = "field")]
			public string Field { get; set; }

			[JsonProperty(PropertyName = "filterOperator")]
			public string FilterOperator { get; set; }

			[JsonProperty(PropertyName = "val")]
			public object Val { get; set; }

			[JsonProperty(PropertyName = "value")]
			public object Value { get; set; }

			[JsonProperty(PropertyName = "apiName")]
			public string ApiName { get; set; }
		}

		public class Paging
		{
			[JsonProperty(PropertyName = "pageLimit")]
			public int PageLimit { get; set; }


			[JsonProperty(PropertyName = "pageNumber")]
			public int PageNumber { get; set; }
		}

		public class Child
		{
			public Child()
			{
				this.Filters = new List<Filter>();
				this.Children = new List<Child>();
			}

			[JsonIgnore]
			public string ApiName { get; set; }

			[JsonProperty(PropertyName = "field")]
			public string Field { get; set; }

			[JsonProperty(PropertyName = "filters")]
			public List<Filter> Filters { get; }

			[JsonProperty(PropertyName = "children")]
			public List<Child> Children { get; }

			[JsonIgnore]
			[JsonProperty(PropertyName = "lookups")]
			[Obsolete("Da capire come gestire")]
			public object Lookups { get; set; }


			public Filter AddFilter(string expressionOperator, string apiName = null)
			{
				if (apiName == null) apiName = ApiName;

				var filter = new Filter
				{
					ExpressionOperator = expressionOperator,
					ApiName = apiName
				};

				this.Filters.Add(filter);
				return filter;
			}

			public Child AddChild(string field, string apiName = null)
			{
				if (apiName == null) apiName = ApiName;

				var child = new Child { ApiName = apiName, Field = field };
				this.Children.Add(child);
				return child;
			}
		}


		public Condition AddCondition(string field, string filterOperator, object val, object value, string apiName = null)
		{
			if (apiName == null) apiName = EntityName;

			var condition = new Condition
			{
				Field = field,
				FilterOperator = filterOperator,
				Val = val,
				Value = value,
				ApiName = apiName
			};

			this.Conditions.Add(condition);
			return condition;
		}

		public Filter AddFilter (string expressionOperator, string apiName = null)
		{
			if (apiName == null) apiName = EntityName;

			var filter = new Filter 
			{ 
				ExpressionOperator = expressionOperator, 
				ApiName = apiName 
			};

			this.Filters.Add(filter);
			return filter;
		}

		public Child AddChild(string field, string apiName = null)
		{
			if (apiName == null) apiName = EntityName;

			var child = new Child { ApiName = apiName, Field = field };
			this.Children.Add(child);
			return child;
		}
	}
}
