using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga
{
	/// <summary>
	/// Generic response for Conga REST api
	/// </summary>
	/// <typeparam name="TData">Type of the "data" attribute</typeparam>
	public abstract class CongaRestResponse<TData> : CongaResponse
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }


		[JsonProperty("data")]
		public TData Data { get; set; }
	}
}
