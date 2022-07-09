using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	/// <summary>
	/// A request that can be used to retrieve record info
	/// </summary>
	/// <see cref="https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_get_field_values.htm"/>
	public class RetrieveRequest : SalesforceRequest
	{
		public RetrieveRequest(string entityName, string id) : base(System.Net.Http.HttpMethod.Get, $"/sobjects/{entityName}/{id}?fields=")
		{
			if (string.IsNullOrWhiteSpace(entityName))
			{
				throw new ArgumentException($"'{nameof(entityName)}' cannot be null or whitespace.", nameof(entityName));
			}

			if (string.IsNullOrWhiteSpace(id))
			{
				throw new ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
			}

			EntityName = entityName;
			Id = id;
			Columns = new List<string>();
			HasBody = false;
		}
		public RetrieveRequest(string entityName, string id, IEnumerable<string> columns)
			: this(entityName, id)
		{
			if (columns == null)
				throw new ArgumentNullException(nameof(columns));

			Columns.AddRange(columns);
		}

		[JsonIgnore]
		public string EntityName { get; }

		[JsonIgnore]
		public string Id { get; }

		[JsonIgnore]
		public List<string> Columns { get; }


		public override string GetUri(CongaEndpoint endpoint)
		{
			var baseUri = base.GetUri(endpoint);
			var uri = baseUri + string.Join(",", Columns);
			return uri;
		}
	}
}
