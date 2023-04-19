namespace Greg.Conga.Sdk.Messages.Salesforce
{
	public class CompositeResponseChildError
	{
        public string ErrorCode { get; set; }

        public string Message { get; set; }

		public override string ToString()
		{
			return $"{ErrorCode}: {Message}";
		}
	}
}
