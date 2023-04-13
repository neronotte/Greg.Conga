using System;

namespace Greg.Conga.Sdk
{
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
	sealed class LabelAttribute : Attribute
	{
		// This is a positional argument
		public LabelAttribute(string labelText)
		{
			this.Label = labelText;
		}

		public string Label { get; }



		public static string GetValue(Enum value)
		{
			var t = value.GetType();
			var fieldInfo = t.GetField(value.ToString());
			var attribute = (LabelAttribute[])fieldInfo.GetCustomAttributes(typeof(LabelAttribute), false);
			if (attribute == null || attribute.Length == 0) return value.ToString();
			return attribute[0].Label;
		}
	}
}
