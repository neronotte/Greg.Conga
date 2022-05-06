using Newtonsoft.Json;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public class Child : IHoldFilters, IHoldChildren, IHoldLookups
	{
		private readonly string apiName;

		internal Child(string apiName)
		{
			this.apiName = apiName;

			this.Filters = new List<Filter>();
			this.Children = new List<Child>();
			this.Lookups = new List<LookupCriteria>();
		}


		[JsonProperty(PropertyName = "field")]
		public string Field { get; set; }

		[JsonProperty(PropertyName = "filters")]
		public List<Filter> Filters { get; }

		[JsonProperty(PropertyName = "children")]
		public List<Child> Children { get; }

		[JsonProperty(PropertyName = "lookups")]
		public List<LookupCriteria> Lookups { get; }



		public string GetApiName()
		{
			return apiName;
		}
	}
}
