using System;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
    public class OrderExpression
    {
        private readonly List<string> clauseList = new List<string>();

        public OrderExpression AddAscending(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName)) throw new ArgumentNullException(nameof(columnName));
            clauseList.Add(columnName);
            return this;
        }

        public OrderExpression AddDescending(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName)) throw new ArgumentNullException(nameof(columnName));
            clauseList.Add(columnName + " DESC");
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", clauseList);
        }
    }
}
