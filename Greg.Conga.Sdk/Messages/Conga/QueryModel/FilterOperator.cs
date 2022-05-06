using System.Runtime.Serialization;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public enum FilterOperator
	{
		[EnumMember(Value="AND")]
		And,

		[EnumMember(Value = "OR")]
		Or
	}
}
