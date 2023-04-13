using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
	public class FilterExpression
	{
		public FilterExpression(LogicalOperator logicalOperator = LogicalOperator.AND)
		{
			LogicalOperator = logicalOperator;
			Filters = new List<FilterExpression>();
			Conditions = new List<IConditionExpression>();
		}

		public LogicalOperator LogicalOperator { get; }

		public List<FilterExpression> Filters { get; }

		public List<IConditionExpression> Conditions { get; }


		public FilterExpression AddCondition(string field, ConditionOperator conditionOperator, params object[] values)
		{
			var conditionExpression = new ConditionExpression(field, conditionOperator, values);
			this.Conditions.Add(conditionExpression);
			return this;
		}

		public FilterExpression AddCustomCondition(string criteria)
		{
			var conditionExpression = new ConditionExpressionCustom(criteria);
			this.Conditions.Add(conditionExpression);
			return this;
		}

		public FilterExpression AddFilter(LogicalOperator logicalOperator = LogicalOperator.AND)
		{
			var childFilter = new FilterExpression(logicalOperator);
			this.Filters.Add(childFilter);
			return childFilter;
		}



		public override string ToString()
		{
			var clauseList = new List<string>();

			foreach (var condition in Conditions)
			{
				var conditionExpression = condition.ToString();
				if (!string.IsNullOrWhiteSpace(conditionExpression))
					clauseList.Add(conditionExpression);
			}

			foreach (var filter in Filters)
			{
				var filterExpression = filter.ToString();
				if (!string.IsNullOrWhiteSpace(filterExpression))
				{
					filterExpression = "(" + filterExpression + ")";
					clauseList.Add(filterExpression);
				}
			}

			return string.Join(" " + this.LogicalOperator + " ", clauseList);
		}
	}
}
