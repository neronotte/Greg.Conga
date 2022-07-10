using Newtonsoft.Json;
using System;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	/// <summary>
	/// A request that can be used to create other records
	/// </summary>
	/// <see cref="https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_sobject_create.htm"/>
	public class CreateRequest : SalesforceRequest
	{
		public CreateRequest(string entityName) : base(System.Net.Http.HttpMethod.Post, $"/sobjects/{entityName}/")
		{
			if (string.IsNullOrWhiteSpace(entityName))
			{
				throw new ArgumentException($"'{nameof(entityName)}' cannot be null or whitespace.", nameof(entityName));
			}

			EntityName = entityName;
		}
		public CreateRequest(string entityName, object target) : this(entityName)
		{
			Target = target ?? throw new ArgumentNullException(nameof(target), $"{nameof(target)} cannot be null");
		}

		[JsonIgnore]
		public string EntityName { get; }


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
