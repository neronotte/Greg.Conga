using Greg.Conga.Sdk.Messages.Conga.QueryModel;
using System;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public static class QueryExtensions
	{
		public static Condition AddCondition(this IHoldConditions container, string field, ConditionOperator conditionOperator, object val = null, string apiName = null)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			if (apiName == null) 
				apiName = container.GetApiName();

			object value = val;
			if (val != null && val.GetType().IsArray)
			{
				var array = (object[])val;
				value = string.Join(",", array);
			}

			var condition = new Condition
			{
				Field = field,
				FilterOperator = conditionOperator,
				Val = val,
				Value = value,
				ApiName = apiName
			};

			container.Conditions.Add(condition);
			return condition;
		}



		public static Filter AddOrFilter(this IHoldFilters container)
		{
			return AddFilter(container, FilterOperator.Or);
		}

		public static Filter AddAndFilter(this IHoldFilters container)
		{
			return AddFilter(container, FilterOperator.And);
		}


		public static Filter AddFilter(this IHoldFilters container, FilterOperator expressionOperator, string apiName = null)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			if (apiName == null)
				apiName = container.GetApiName();

			var filter = new Filter(apiName)
			{
				ExpressionOperator = expressionOperator
			};

			container.Filters.Add(filter);
			return filter;
		}





		public static Child AddChild(this IHoldChildren container, string field, string apiName = null)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			if (apiName == null)
				apiName = container.GetApiName();

			var child = new Child(apiName)
			{ 
				Field = field 
			};
			container.Children.Add(child);
			return child;
		}




		public static LookupCriteria AddLookup(this IHoldLookups container, string field, string apiName = null)
		{
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			if (apiName == null)
				apiName = container.GetApiName();

			var lookupCriteria = new LookupCriteria(apiName) { Field = field };
			container.Lookups.Add(lookupCriteria);
			return lookupCriteria;
		}
	}
}
