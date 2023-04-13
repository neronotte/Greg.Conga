using System;
using System.Text;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
    public sealed class QueryExpression : IOrderExpressionBuilder
	{
		public QueryExpression(string from)
		{
			if (string.IsNullOrWhiteSpace(from))
				throw new ArgumentNullException(nameof(from));

			this.From = from;
			this.Select = new ColumnSet();
			this.Order = new OrderExpression();
		}


		public ColumnSet Select { get; }

		public string From { get; }

		public FilterExpression Where { get; set; }

		public OrderExpression Order { get; }

		public ColumnSet Groups { get; set; }

		public int? Limit { get; set; }







		public void AddColumns(params string[] columnNames)
		{
			if (columnNames == null) columnNames = Array.Empty<string>();
			Select.AddRange(columnNames);
		}


		public QueryExpression AddCondition(string field, ConditionOperator conditionOperator, params object[] values)
		{
			if (this.Where == null) this.Where = new FilterExpression();
			this.Where.AddCondition(field, conditionOperator, values);
			return this;
		}

		public QueryExpression AddCustomCondition(string criteria)
		{
			if (this.Where == null) this.Where = new FilterExpression();
			this.Where.AddCustomCondition(criteria);
			return this;
		}



		public QueryExpression GroupBy(params string[] columnNames)
		{
			if (columnNames == null || columnNames.Length == 0)
				return this;

			if (this.Groups == null) this.Groups = new ColumnSet();
			this.Groups.AddRange(columnNames);
			return this;
		}






		public IOrderExpressionBuilder OrderBy(params string[] columnNames)
		{
			if (columnNames == null || columnNames.Length == 0)
				return this;

			foreach (var columName in columnNames)
			{
				Order.AddAscending(columName);
			}
			return this;
		}
		public IOrderExpressionBuilder OrderByDescending(params string[] columnNames)
		{
			if (columnNames == null || columnNames.Length == 0)
				return this;

			foreach (var columName in columnNames)
			{
				Order.AddDescending(columName);
			}
			return this;
		}

		IOrderExpressionBuilder IOrderExpressionBuilder.ThenBy(params string[] columnNames)
		{
			if (columnNames == null || columnNames.Length == 0)
				return this;

			foreach (var columName in columnNames)
			{
				Order.AddAscending(columName);
			}
			return this;
		}

		IOrderExpressionBuilder IOrderExpressionBuilder.ThenByDescending(params string[] columnNames)
		{
			if (columnNames == null || columnNames.Length == 0)
				return this;

			foreach (var columName in columnNames)
			{
				Order.AddDescending(columName);
			}
			return this;
		}




		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.Append("SELECT ");
			sb.Append(Select.ToString());
			sb.Append(" FROM ").Append(this.From);


			var whereClause = this.Where?.ToString();
			if (!string.IsNullOrWhiteSpace(whereClause))
			{
				sb.Append(" WHERE ").Append(whereClause);
			}

			var orderClause = this.Order.ToString();
			if (!string.IsNullOrWhiteSpace(orderClause))
			{
				sb.Append(" ORDER BY ").Append(orderClause);
			}

			var groupByClause = this.Groups?.ToString();
			if (!string.IsNullOrWhiteSpace(groupByClause))
			{
				sb.Append(" GROUP BY ").Append(groupByClause);
			}

			if (this.Limit != null)
			{
				sb.Append(" LIMIT ").Append(this.Limit.GetValueOrDefault());
			}

			return sb.ToString();
		}
	}
}
