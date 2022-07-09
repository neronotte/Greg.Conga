using System;
using System.Collections.Generic;

namespace Greg.Conga.WinUI.Model
{
	internal class FieldNameComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			if (x == y) return 0;
			if (x == null) return -1;
			if (y == null) return 1;

			if (string.Equals(x, "ID", StringComparison.OrdinalIgnoreCase)) return -1;
			if (string.Equals(y, "ID", StringComparison.OrdinalIgnoreCase)) return 1;
			if (string.Equals(x, "Name", StringComparison.OrdinalIgnoreCase)) return -1;
			if (string.Equals(y, "Name", StringComparison.OrdinalIgnoreCase)) return 1;

			return x.CompareTo(y);
		}
	}
}
