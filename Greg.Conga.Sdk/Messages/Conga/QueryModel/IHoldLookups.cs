using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public interface IHoldLookups
	{
		string GetApiName();

		List<LookupCriteria> Lookups { get; }
	}

}
