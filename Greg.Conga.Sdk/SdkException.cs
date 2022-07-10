using Greg.Conga.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Conga.Sdk
{

	[Serializable]
	public class SdkException : Exception
	{
		protected SdkException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}


		public SdkException(BaseRequest request, BaseResponse response, string message) : base(message)
		{
			this.Request = request ?? throw new ArgumentNullException(nameof(request));
			this.Response = response ?? throw new ArgumentNullException(nameof(response));
		}

		public BaseRequest Request { get; private set; }
		public BaseResponse Response { get; private set; }
	}
}
