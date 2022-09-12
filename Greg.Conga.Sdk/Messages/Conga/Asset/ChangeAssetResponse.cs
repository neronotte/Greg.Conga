namespace Greg.Conga.Sdk.Messages.Conga.Asset
{
    public class ChangeAssetResponse : CongaRestResponse<ChangeAssetResponseBody>
    {
    }


    public class ChangeAssetResponseBody
    {
        public ChangeAssetResponseBodyPageErrors PageErrors { get; set; }
        public string NextStep { get; set; }
        public bool HasError { get; set; }
        public int LineNumber { get; set; }
        public string Cause { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
    }

    public class ChangeAssetResponseBodyPageErrors
    {
        public string[] WarningMessages { get; set; }
        public string[] SuccessMessages { get; set; }
        public string[] InfoMessages { get; set; }
        public string[] ErrorMessages { get; set; }

        public ChangeAssetResponseBodyPageErrorsPricingResponse PricingResponse { get; set; }

        public ChangeAssetResponseBodyPageErrorsConstraintResult ConstraintResult { get; set; }
    }

    public class ChangeAssetResponseBodyPageErrorsPricingResponse
    {
        public object[] PendingLineNumbers { get; set; }
        public object[] ErrorLineNumbers { get; set; }
        public object[] CompletedLineNumbers { get; set; }

        public bool IsTotalPricePending { get; set; }
        public bool IsPricePending { get; set; }
        public bool IsPrePricePending { get; set; }
        public bool IsPostPricePending { get; set; }
    }


    public class ChangeAssetResponseBodyPageErrorsConstraintResult
    {
        public bool NeedMoreProcessing { get; set; }
        public bool HasPendingWarning { get; set; }
        public bool HasPendingError { get; set; }
        public object[] ConstraintRuleActions { get; set; }
        public string CartId { get; set; }
    }
}
