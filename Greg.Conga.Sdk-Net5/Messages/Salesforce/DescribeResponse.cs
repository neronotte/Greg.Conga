using Newtonsoft.Json;
using System.Diagnostics;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	[DebuggerDisplay("{StatusCode}: {Name}")]
	public class DescribeResponse : SalesforceResponse
	{
		[JsonProperty("custom")]
		public bool Custom { get; set; }

		[JsonProperty("fields")]
		public FieldDefinition[] Fields { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }

		[JsonProperty("labelPlural")]
		public string LabelPlural { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("childRelationships")]
		public RelationshipDefinition[] ChildRelationships { get; set; }




		[DebuggerDisplay("{Name}: {Type}")]
		public class FieldDefinition
		{
			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("type")]
			public string Type { get; set; }

			[JsonProperty("label")]
			public string Label { get; set; }

			[JsonProperty("calculatedFormula")]
			public string CalculatedFormula { get; set; }

			[JsonProperty("length")]
			public int Length { get; set; }

			[JsonProperty("picklistValues")]
			public PicklistValueDefinition[] PicklistValues { get; set; }

			[JsonProperty("referenceTo")]
			public string[] ReferenceTo { get; set; }
		}



		[DebuggerDisplay("{Value}")]
		public class PicklistValueDefinition
		{
			[JsonProperty("Active")]
			public bool Active { get; set; }

			[JsonProperty("defaultValue")]
			public bool DefaultValue { get; set; }

			[JsonProperty("label")]
			public string Label { get; set; }

			[JsonProperty("value")]
			public string Value { get; set; }
		}




		[DebuggerDisplay("{Field}: {ChildSObject}")]
		public class RelationshipDefinition
		{
			[JsonProperty("cascadeDelete")]
			public bool CascadeDelete { get; set; }

			[JsonProperty("childSObject")]
			public string ChildSObject { get; set; }

			[JsonProperty("deprecatedAndHidden")]
			public bool DeprecatedAndHidden { get; set; }

			[JsonProperty("field")]
			public string Field { get; set; }

			[JsonProperty("relationshipName")]
			public string RelationshipName { get; set; }
		}

	}
}
