namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
    public interface IOrderExpressionBuilder
    {
        IOrderExpressionBuilder ThenBy(params string[] columnNames);
        IOrderExpressionBuilder ThenByDescending(params string[] columnNames);
    }
}
