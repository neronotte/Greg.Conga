using Newtonsoft.Json;
using System;

namespace Greg.Conga.Sdk.Messages
{
	public abstract class BaseRequest
	{
		public BaseRequest(string method, string urlPart)
		{
			if (string.IsNullOrWhiteSpace(method))
			{
				throw new ArgumentException($"'{nameof(method)}' cannot be null or whitespace.", nameof(method));
			}

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
		public string Method { get; }

		[JsonIgnore]
		public string UrlPart { get; }



		public abstract string GetUri(CongaEndpoint endpoint);


		public virtual string ToSerializedObject()
		{
			return JsonConvert.SerializeObject(this, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			});
		}
	}
}
