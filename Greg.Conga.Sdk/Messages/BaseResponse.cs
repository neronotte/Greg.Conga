using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Net;

namespace Greg.Conga.Sdk.Messages
{
	public abstract class BaseResponse
	{
		public string Raw { get; internal set; }
		public HttpStatusCode StatusCode { get; internal set; }
		public string StatusDescription { get; internal set; }


		private ExpandoObject rawObject;

		public dynamic RawObject
		{
			get
			{
				if (rawObject == null)
				{
					var converter = new ExpandoObjectConverter();
					rawObject = JsonConvert.DeserializeObject<ExpandoObject>(Raw, converter);
				}
				return rawObject;
			}
		}
	}
}
