using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Greg.Conga.Sdk.Messages
{
	public abstract class BaseRequest
	{
		public BaseRequest(HttpMethod method, string urlPart)
		{
			if (string.IsNullOrWhiteSpace(urlPart))
			{
				throw new ArgumentException($"'{nameof(urlPart)}' cannot be null or whitespace.", nameof(urlPart));
			}

			Method = method;
			UrlPart = urlPart;
			HasBody = true;
		}


		[JsonIgnore]
		public bool HasBody { get; protected set; }

		[JsonIgnore]
		public HttpMethod Method { get; protected set; }

		[JsonIgnore]
		public string UrlPart { get; protected set; }



		public abstract string GetUri(CongaEndpoint endpoint);


		public virtual string ToSerializedObject()
		{
			return JsonConvert.SerializeObject(this, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			});
		}

		internal virtual void AddAdditionalHeaders(HttpRequestMessage request1)
		{
		}
	}
}
