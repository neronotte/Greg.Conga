using Greg.Conga.Sdk;
using Greg.Conga.Sdk.Messages.Salesforce;
using System.Collections.Generic;
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


		public async Task<DescribeResponse> GetMetadataForEntityAsync(string entityName)
		{
			if (this.cache.TryGetValue(entityName, out DescribeResponse response)) return response;

			response = await this.service.ExecuteAsync<DescribeResponse>(new DescribeRequest(entityName));

			this.cache[entityName] = response;
			return response;
		}
	}
}
