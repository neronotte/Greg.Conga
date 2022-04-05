using System.Text.RegularExpressions;

namespace Greg.Conga.Sdk.Messages.Conga
{

	public abstract class CongaRequest : BaseRequest
	{
		public CongaRequest(string method, string urlPart) : base(method, urlPart)
		{
		}

		public override string GetUri(CongaEndpoint endpoint)
		{
			var firstPart = endpoint.RestApiRootEndpoint.TrimEnd('/');
			var urlPart = UrlPart.TrimStart('/');

			urlPart = Regex.Replace(urlPart, "\\{\\w+\\}", m =>
			{

				var propertyName = m.Value.Trim("{}".ToCharArray());
				var property = GetType().GetProperty(propertyName);
				var propertyValue = property.GetValue(this, null);
				return propertyValue?.ToString() ?? string.Empty;
			});



			return firstPart + "/" + urlPart;
		}
	}
}
