using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Hidden <{Field}>")]
	public class DataValidationRuleHidden : IDataValidationRule
	{
		public DataValidationRuleHidden(string field)
		{
			this.Field = field;
		}

		public string Field { get; }
		public int Order { get; } = 4;

		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;
			if (!propertyDict.TryGetValue(Field, out string value))
				return true;

			if (string.IsNullOrWhiteSpace(value))
				return true;

			errorMessage = $"Field <{Field}> should not be provided!";
			return false;
		}
	}
}
