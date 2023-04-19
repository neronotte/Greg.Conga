using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class CompositeResponseChild
	{
		[JsonProperty(PropertyName = "referenceId")]
		public string ReferenceId { get; set; }

		[JsonProperty(PropertyName = "httpStatusCode")]
		public int? HttpStatusCode { get; set; }

		[JsonProperty(PropertyName = "body")]
		public JToken Body { get; set; }

		[JsonProperty(PropertyName = "httpHeaders")]
		public JToken HttpHeaders { get; set; }


		public T GetBody<T>()
		{
			return Body.ToObject<T>();
		}

		[JsonIgnore]
		public CompositeResponseChildError Error
		{
			get 
			{
				try
				{
					return Body.ToObject<CompositeResponseChildError[]>()?.FirstOrDefault();
				}
				catch
				{
					return null;
				}
			}
		}


		public override string ToString()
		{
			var error = Error;
			if (error != null) return error.ToString();

			return Body.ToString();
		}
	}
}
