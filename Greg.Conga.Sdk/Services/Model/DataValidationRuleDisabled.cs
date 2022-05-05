using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Disable <{Field}>")]
	public class DataValidationRuleDisabled : IDataValidationRule
	{
		public DataValidationRuleDisabled(string field)
		{
			this.Field = field;
		}

		public string Field { get; }
		public int Order { get; } = 5;


		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;
			return true;
		}
	}
}
