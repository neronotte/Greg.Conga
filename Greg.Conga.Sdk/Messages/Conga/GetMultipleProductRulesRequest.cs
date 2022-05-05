using System.Text;

namespace Greg.Conga.Sdk.Messages.Conga
{
	public class GetMultipleProductRulesRequest : CongaRequest
	{
		public GetMultipleProductRulesRequest(params string[] productIds) : base("POST", "/products/rules")
		{
			ProductIds = productIds;
		}

		public string[] ProductIds { get; }

		public override string ToSerializedObject()
		{
			var sb = new StringBuilder();
			sb.Append("[");

			for (int i = 0; i < ProductIds.Length; i++)
			{
				sb.Append("{ \"Id\": \"").Append(ProductIds[i]).Append("\" }");
				if (i < ProductIds.Length - 1)
					sb.Append(",");
			}

			sb.Append("]");
			return sb.ToString();
		}
	}
}
