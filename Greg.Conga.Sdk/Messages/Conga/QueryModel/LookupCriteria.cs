using Newtonsoft.Json;
using System.Collections.Generic;

namespace Greg.Conga.Sdk.Messages.Conga.QueryModel
{
	public class LookupCriteria : IHoldChildren, IHoldLookups
	{
		private readonly string apiName;

		public LookupCriteria(string apiName)
		{
			this.apiName = apiName;
			this.Lookups = new List<LookupCriteria>();
			this.Children = new List<Child>();
		}




		[JsonProperty(PropertyName = "field")]
		public string Field { get; set; }


		[JsonProperty(PropertyName = "lookups")]
		public List<LookupCriteria> Lookups { get; }


		[JsonProperty(PropertyName = "children")]
		public List<Child> Children { get; }



		public string GetApiName()
		{
			return apiName;
		}
	}
}
