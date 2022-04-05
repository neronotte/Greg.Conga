namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetActivePricelistRequest : CongaRequest
	{
		public GetActivePricelistRequest() : base("GET", "/pricelists/active")
		{
			HasBody = false;
		}
	}
}
