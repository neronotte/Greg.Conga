using Newtonsoft.Json;
using System;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	/// <summary>
	/// A request that can be used to update records
	/// </summary>
	/// <see cref="https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_update_fields.htm"/>
	public class UpdateRequest : SalesforceRequest
	{
		public UpdateRequest(string entityName, string id) : base("PATCH", $"/sobjects/{entityName}/{id}")
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
		}

		public UpdateRequest(string entityName, string id, object target) : this(entityName, id)
		{
			if (target == null)
				throw new ArgumentNullException(nameof(target), $"{nameof(target)} cannot be null");

			Target = target;
		}

		[JsonIgnore]
		public string EntityName { get; }

		[JsonIgnore]
		public string Id { get; }

		/// <summary>
		/// The object that contains the properties
		/// </summary>
		public object Target { get; set; }


		public override string ToSerializedObject()
		{
			return JsonConvert.SerializeObject(Target, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			});
		}
	}
}
