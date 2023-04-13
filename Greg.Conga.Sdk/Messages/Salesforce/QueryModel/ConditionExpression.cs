using System;
using System.Linq;
using System.Text;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
	public class ConditionExpression : IConditionExpression
    {
        public ConditionExpression(string field, ConditionOperator conditionOperator, params object[] values)
        {
			if (string.IsNullOrWhiteSpace(field))
			{
				throw new ArgumentNullException(nameof(field));
			}

			this.Field = field;
			this.ConditionOperator = conditionOperator;
			this.Values = values ?? Array.Empty<object>();
		}

		public string Field { get; }
		public ConditionOperator ConditionOperator { get; }
		public object[] Values { get; }


		public override string ToString()
		{
            var sb = new StringBuilder();
            sb.Append(Field).Append(' ').Append(LabelAttribute.GetValue(ConditionOperator));

            if (Values != null && Values.Length > 0)
            {
                sb.Append(' ');
                if (Values.Length == 1) 
                {
                    sb.Append(ParseValue(Values[0]));
                }
                else
				{
					sb.Append('(');
					sb.Append(string.Join(", ", Values.Select(x => ParseValue(x))));
					sb.Append(')');
				}
            }

            return sb.ToString();
		}


        private static string ParseValue(object value)
        {
            if (value == null) return "null";
            if (value is string sValue) return "'" + sValue + "'";
            if (value is DateTime dtValue) return dtValue.ToString("u"); //2023-04-13T10:51:54.393z 

			return value.ToString();
        }
	}
}
