using Greg.Conga.Sdk;
using Greg.Conga.Sdk.Messages;
using System.Collections.Generic;

namespace Greg.Conga.WinUI.Model
{
	public class DataRepository
	{
		private readonly Dictionary<string, DynamicEntity> cache = new Dictionary<string, DynamicEntity>();
		private readonly ICongaService service;

		public DataRepository(ICongaService service)
		{
			this.service = service;
		}


		public DynamicEntity Get(string id, string entityName, string[] columns)
		{
			var key = $"{entityName}|{id}";

			if (cache.TryGetValue(key, out DynamicEntity entity)) return entity;

			entity = this.service.Retrieve<DynamicEntity>(entityName, id, columns);
			cache[key] = entity;
			return entity;
		}
	}
}
