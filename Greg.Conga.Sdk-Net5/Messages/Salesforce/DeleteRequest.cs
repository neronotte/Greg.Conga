using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	/// <summary>
	/// Deletes a specific record
	/// </summary>
	/// <see cref="https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_delete_record.htm"/>
	public class DeleteRequest : SalesforceRequest
	{
		public DeleteRequest(string entityName, string id) : base("DELETE", $"/sobjects/{entityName}/{id}")
		{
			if (string.IsNullOrWhiteSpace(entityName))
			{
				throw new System.ArgumentException($"'{nameof(entityName)}' cannot be null or whitespace.", nameof(entityName));
			}

			if (string.IsNullOrWhiteSpace(id))
			{
				throw new System.ArgumentException($"'{nameof(id)}' cannot be null or whitespace.", nameof(id));
			}

			EntityName = entityName;
			Id = id;
			HasBody = false;
		}

		[JsonIgnore]
		public string EntityName { get; }

		[JsonIgnore]
		public string Id { get; }
	}
}
