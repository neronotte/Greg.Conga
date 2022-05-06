using System.Runtime.Serialization;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public enum Order
	{
		[EnumMember(Value = "ASC")]
		Ascending,

		[EnumMember(Value = "DESC")]
		Descending
	}
}
