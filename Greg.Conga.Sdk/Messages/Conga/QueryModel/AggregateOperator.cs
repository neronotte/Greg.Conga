using System.Runtime.Serialization;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public enum AggregateOperator
	{

		[EnumMember(Value = "SUM")]
		Sum,

		[EnumMember(Value = "MIN")]
		Min,
		
		[EnumMember(Value = "MAX")]
		Max,
		
		[EnumMember(Value = "AVG")]
		Average,
		
		[EnumMember(Value = "COUNT")]
		Count,
	}



}
