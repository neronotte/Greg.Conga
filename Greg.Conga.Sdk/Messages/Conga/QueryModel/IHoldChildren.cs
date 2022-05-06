using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public interface IHoldChildren
	{
		string GetApiName();

		List<Child> Children { get; }
	}

}
