using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public interface IHoldConditions
	{
		string GetApiName();

		List<Condition> Conditions { get; }
	}

}
