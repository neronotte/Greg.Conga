using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Required <{Field}>")]
	public class DataValidationRuleRequired : IDataValidationRule
	{
		public DataValidationRuleRequired(string field)
		{
			this.Field = field;
		}

		public string Field { get; }
		public int Order { get; } = 2;


		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = $"Field <{Field}> is required!";

			if (!propertyDict.TryGetValue(Field, out string value)) 
				return false;

			if (string.IsNullOrWhiteSpace(value))
				return false;

			errorMessage = null;
			return true;
		}
	}
}
