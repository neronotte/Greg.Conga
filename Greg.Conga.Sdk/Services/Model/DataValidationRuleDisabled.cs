using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Disable <{Field}> ({IsEnabled})")]
	public class DataValidationRuleDisabled : IDataValidationRule
	{
		public DataValidationRuleDisabled(string field, bool isEnabled)
		{
			this.Field = field;
			this.IsEnabled = isEnabled;
		}

		public string Field { get; }
		public bool IsEnabled { get; }
		public int Order { get; } = 2;


		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;
			if (!propertyDict.TryGetValue(Field, out string value))
				return true;

			if (string.IsNullOrWhiteSpace(value))
				return true;

			errorMessage = $"Field <{Field}> should not be provided (disabled)!";
			return false;
		}
	}
}
