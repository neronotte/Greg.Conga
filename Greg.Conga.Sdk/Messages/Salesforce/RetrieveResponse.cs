using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	/// <summary>
	/// Response to a <see cref="RetrieveRequest"/>
	/// </summary>
	public class RetrieveResponse : SalesforceResponse
	{
		public T ToEntity<T>()
		{
			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
			var entity = JsonConvert.DeserializeObject<T>(Raw, settings);
			return entity;
		}
	}
}
