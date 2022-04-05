using Greg.Conga.Sdk.Messages;
using System;
using System.Runtime.Serialization;

namespace Greg.Conga.Sdk.Exceptions
{
	[Serializable]
	internal class SalesforceException : Exception
	{
		public SalesforceException()
		{
		}

		public SalesforceException(string message) : base(message)
		{
		}

		public SalesforceException(string errorCode, string message)
			: this($"[{errorCode}] {message}")
		{
		}

		public SalesforceException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected SalesforceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		public BaseResponse Response { get; set; }
	}
}