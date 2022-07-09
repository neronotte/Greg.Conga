using Greg.Conga.Sdk;
using Greg.Conga.Sdk.Messages.Salesforce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Conga.WinUI.Model
{
	public class MetadataRepository
	{
		private readonly ICongaService service;
		private readonly Dictionary<string, DescribeResponse> cache = new Dictionary<string, DescribeResponse>();

		public MetadataRepository(ICongaService service)
		{
			this.service = service;
		}


		public DescribeResponse GetMetadataForEntity(string entityName)
		{
			if (this.cache.TryGetValue(entityName, out DescribeResponse response)) return response;

			response = this.service.Execute<DescribeResponse>(new DescribeRequest(entityName));
			
			this.cache[entityName] = response;
			return response;
		}
	}
}
