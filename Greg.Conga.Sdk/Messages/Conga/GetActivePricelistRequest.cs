namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetActivePricelistRequest : CongaRequest
	{
		public GetActivePricelistRequest() : base(System.Net.Http.HttpMethod.Get, "/pricelists/active")
		{
			HasBody = false;
		}
	}
}
