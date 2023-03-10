using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Allow <{Field}> values <{ValueString}> ({IsEnabled})")]
	public class DataValidationRuleAllow : IDataValidationRule
	{
		public string Field { get; }
		public string ValueString { get; }
		public bool IsEnabled { get; }
		public int Order { get; } = 5;

		private readonly string[] values;

		public DataValidationRuleAllow(string field, string valueString, bool isEnabled)
		{
			this.Field = field;
			this.ValueString = valueString;
			this.IsEnabled = isEnabled;
			this.values = valueString.Split(';');
		}

		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;
			if (!propertyDict.TryGetValue(Field, out string value))
				return true;

			if (string.IsNullOrWhiteSpace(value)) // questa regola non valida l'obbligatorietà, ma solo la lista valori ove presente
				return true;

			if (values.Any(x => x.Equals(value, System.StringComparison.Ordinal)))
				return true;


			errorMessage = $"Value not permitted for field <{Field}>, expected <{ValueString}>, actual <{value}>";
			return false;
		}
	}
}
