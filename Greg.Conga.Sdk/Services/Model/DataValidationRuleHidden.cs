using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Hidden <{Field}> ({IsEnabled})")]
	public class DataValidationRuleHidden : IDataValidationRule
	{
		public DataValidationRuleHidden(string field, bool isEnabled)
		{
			this.Field = field;
			this.IsEnabled = isEnabled;
		}

		public string Field { get; }
		public bool IsEnabled { get; }
		public int Order { get; } = 1;

		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;
			if (!propertyDict.TryGetValue(Field, out string value))
				return true;

			if (string.IsNullOrWhiteSpace(value))
				return true;

			errorMessage = $"Field <{Field}> should not be provided (hidden)!";
			return false;
		}
	}
}
