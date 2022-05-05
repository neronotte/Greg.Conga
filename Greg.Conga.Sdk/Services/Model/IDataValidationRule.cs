using System.Collections.Generic;

namespace Greg.Conga.Sdk.Services.Model
{
	public interface IDataValidationRule
	{
		int Order { get; }
		string Field { get; }
		bool TryValidate(Dictionary<string, string> propertyDict, out string errorMessage);
	}
}
