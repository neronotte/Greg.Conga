namespace Greg.Conga.Sdk.Messages.Conga
{
	public class CreateCartRequest : CongaRequest
	{
		public CreateCartRequest()
		: base("POST", "/carts?alias=false")
		{
		}


		public string Name { get; set; }

		public string egl_sales_process__c { get; set; }
	}
}
