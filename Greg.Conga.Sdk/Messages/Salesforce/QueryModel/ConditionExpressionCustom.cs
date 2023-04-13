namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
	public class ConditionExpressionCustom : IConditionExpression
    {
        public ConditionExpressionCustom(string criteria)
        {
			this.Criteria = criteria;
		}

		public string Criteria { get; }

		public override string ToString()
		{
            return Criteria;
		}
	}
}
