using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Allow <{Field}> values <{ValueString}>")]
	public class DataValidationRuleAllow : IDataValidationRule
	{
		public string Field { get; }
		public string ValueString { get; }
		public int Order { get; } = 3;

		private readonly string[] values;

		public DataValidationRuleAllow(string field, string valueString)
		{
			this.Field = field;
			this.ValueString = valueString;
			this.values = valueString.Split(',');
		}

		public bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage)
		{
			errorMessage = null;
			if (!propertyDict.TryGetValue(Field, out string value))
				return true;

			if (string.IsNullOrWhiteSpace(value)) // questa regola non valida l'obbligatorietà, ma solo la lista valori ove presente
				return true;

			if (values.Any(x => x.Equals(value)))
				return true;


			errorMessage = $"Value not permitted for field <{Field}>, expected <{ValueString}>, actual <{value}>";
			return false;
		}

		private string GetDebuggerDisplay()
		{
			return ToString();
		}
	}
}
