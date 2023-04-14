using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
	class ColumnDataExtractor
	{
		public ColumnDataExtractor(string columnName)
		{
			this.ColumnName = columnName;
			this.Parts = Parse(columnName);
		}

		private static string[] Parse(string columnName)
		{
			if (string.IsNullOrWhiteSpace(columnName)) return Array.Empty<string>();
			if (columnName.Contains('(')) return Array.Empty<string>();
			return columnName.Split('.');
		}

		public string ColumnName { get; }


		public string[] Parts { get; }


		public object ExtractFrom(JObject record)
		{
			if (record == null)
				throw new ArgumentNullException(nameof(record));

			if (Parts.Length == 0)
			{
				throw new NotImplementedException("Parts.Length == 0");
			}

			if (Parts.Length == 1)
			{
				if (record.TryGetValue(Parts[0], StringComparison.OrdinalIgnoreCase, out var childToken))
				{
					if (childToken is JValue childValueToken)
					{
						return childValueToken.Value;
					}

					throw new NotSupportedException($"Error readong data from column {ColumnName}. Expected a JValue, found a {childToken.GetType().Name}.");
				}
				return null;
			}


			return Recourse(record, Parts, 0);
		}

		private object Recourse(JObject record, string[] parts, int index)
		{
			if (index >= parts.Length) return null;

			var fieldName = parts[index];
			if (!record.TryGetValue(fieldName, StringComparison.OrdinalIgnoreCase, out var childToken))
				return null;

			if (index == parts.Length - 1)
			{
				if (childToken is JValue childValueToken)
				{
					return childValueToken.Value;
				}

				throw new NotSupportedException($"Error readong data from column {ColumnName} at token index {index} ({fieldName}). Expected a JValue, found a {childToken.GetType().Name}.");
			}


			if (!(childToken is JObject childObject))
				return null;

			return Recourse(childObject, parts, index + 1);
		}
	}
}
