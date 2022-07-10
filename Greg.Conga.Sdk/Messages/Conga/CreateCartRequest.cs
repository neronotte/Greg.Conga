namespace Greg.Conga.Sdk.Messages.Conga
{
	public class CreateCartRequest : CongaRequest
	{
		public CreateCartRequest()
		: base(System.Net.Http.HttpMethod.Post, "/carts?alias=false")
		{
		}


		public string Name { get; set; }

#pragma warning disable CA1707 // Identifiers should not contain underscores
		public string egl_sales_process__c { get; set; }
#pragma warning restore CA1707 // Identifiers should not contain underscores
	}
}
