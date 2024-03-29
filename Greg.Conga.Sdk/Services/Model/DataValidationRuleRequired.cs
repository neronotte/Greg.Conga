﻿using System.Collections.Generic;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Services.Model
{
	[DebuggerDisplay("Required <{Field}> ({IsEnabled})")]
	public class DataValidationRuleRequired : IDataValidationRule
	{
		public DataValidationRuleRequired(string field, bool isEnabled)
		{
			this.Field = field;
			this.IsEnabled = isEnabled;
		}

		public string Field { get; }
		public bool IsEnabled { get; }
		public int Order { get; } = 4;


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
