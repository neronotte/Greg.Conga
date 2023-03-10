using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Default for <{Field}> set <{ValueString}> ({IsEnabled})")]
	public class DataValidationRuleDefault : IDataValidationRule
	{
		public string Field { get; }
		public string ValueString { get; }
		public bool IsEnabled { get; }
		public int Order { get; } = 3;

		public DataValidationRuleDefault(string field, string valueString, bool isEnabled)
		{
			this.Field = field;
			this.ValueString = valueString;
			this.IsEnabled = isEnabled;
		}

		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;

			if (!propertyDict.TryGetValue(Field, out string value))
			{
				propertyDict[Field] = ValueString;
				return true;
			}

			if (string.IsNullOrWhiteSpace(value))
			{
				propertyDict[Field] = ValueString;
				return true;
			}

			return true;
		}
	}
}
