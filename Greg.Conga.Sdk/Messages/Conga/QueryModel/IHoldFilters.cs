using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public interface IHoldFilters
	{
		string GetApiName();

		List<Filter> Filters { get; }
	}

}
