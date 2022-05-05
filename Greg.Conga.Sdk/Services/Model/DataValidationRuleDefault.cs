using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Default for <{Field}> set <{ValueString}>")]
	public class DataValidationRuleDefault : IDataValidationRule
	{
		public string Field { get; }
		public string ValueString { get; }

		public int Order { get; } = 1;

		public DataValidationRuleDefault(string field, string valueString)
		{
			this.Field = field;
			this.ValueString = valueString;
		}

		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;

			if (!propertyDict.ContainsKey(Field))
			{
				propertyDict[Field] = ValueString;
			}

			return true;
		}
	}
}
