using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Greg.Conga.Sdk.Messages.Salesforce
{
    /// <summary>
    /// You can have up to 25 subrequests in a single call. 
    /// Up to 5 of these subrequests can be sObject Collections or query operations, 
    /// including Query and QueryAll requests.
    /// 
    /// https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/requests_composite.htm
    /// </summary>
    public class CompositeRequest : SalesforceRequest
	{
		public CompositeRequest() : base(HttpMethod.Post, "/composite")
		{
			this.Children = new List<CompositeRequestChild>();
		}

		/// <summary>
		/// Specifies what to do when an error occurs while processing a subrequest. 
		/// If the value is true, the entire composite request is rolled back. 
		/// The top-level request returns HTTP 200 and includes responses for each subrequest.
		/// 
		/// If the value is false, the remaining subrequests that don’t depend on the failed 
		/// subrequest are executed.Dependent subrequests aren’t executed.
		/// 
		/// In either case, the top-level request returns HTTP 200 and includes responses for each subrequest.
		/// </summary>
		[JsonProperty(PropertyName = "allOrNone")]
        public bool AllOrNone { get; set; }







		[JsonProperty(PropertyName = "compositeRequest")]
		public List<CompositeRequestChild> Children { get; }



		public virtual void Add(HttpMethod method, string url, string referenceId, object body = null, object httpHeaders = null) 
		{
			this.Children.Add(new CompositeRequestChild
			{
				Method = method.Method,
				Url = url,
				ReferenceId = referenceId,
				Body = body,
				HttpHeaders = httpHeaders
			});
		}
    }
}
