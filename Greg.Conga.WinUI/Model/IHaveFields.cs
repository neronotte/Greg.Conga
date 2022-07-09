using System.Collections.Generic;

namespace Greg.Conga.WinUI.Model
{
	public interface IHaveFields 
	{
		List<FieldDescriptor> Fields { get; }
	}
}
