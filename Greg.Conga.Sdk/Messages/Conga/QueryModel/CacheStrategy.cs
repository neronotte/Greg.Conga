using System.Runtime.Serialization;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public enum CacheStrategy
	{
		[EnumMember(Value = "freshness")]
		Freshness,

		[EnumMember(Value = "performance")]
		Performance
	}
}
