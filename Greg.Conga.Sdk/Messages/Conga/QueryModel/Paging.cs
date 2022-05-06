using Newtonsoft.Json;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public class Paging
	{
		internal Paging() { }

		[JsonProperty(PropertyName = "pageLimit")]
		public int PageLimit { get; set; }


		[JsonProperty(PropertyName = "pageNumber")]
		public int PageNumber { get; set; }
	}
}
