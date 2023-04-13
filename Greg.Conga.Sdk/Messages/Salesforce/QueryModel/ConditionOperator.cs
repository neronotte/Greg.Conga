namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
	public enum ConditionOperator
	{
		[Label("=")]
		Equal,

		[Label("<=")]
		LessEqual,

		[Label("<>")]
		NotEqual,

		[Label(">=")]
		GreaterEqual,

		[Label(">")]
		GreaterThan,

		[Label("LIKE")]
		Like,

		[Label("IN")]
		In,

		[Label("<")]
		LessThan,

		[Label("NOT LIKE")]
		NotLike,
		[Label("NOT IN")]
		NotIn,

		[Label("= ''")]
		Null,

		[Label("<> ''")]
		NotNull,

		[Label("= TODAY")]
		Today,

		[Label("= TOMORROW")]
		Tomorrow,

		[Label("INCLUDES")]
		Includes
	}
}
