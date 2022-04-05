using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages
{
	public class DynamicEntity : Dictionary<string, object>
	{
		public string Id
		{
			get
			{
				if (TryGetValue("Id", out object id)) return (string)id;
				return null;
			}
		}

		public T Get<T>(string propertyName)
		{
			if (TryGetValue(propertyName, out object value)) return (T)value;
			return default;
		}
	}
}
