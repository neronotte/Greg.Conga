using Greg.Conga.Sdk.Messages;

namespace Greg.Conga.Sdk
{
	public interface ICongaService
	{
		void Authenticate(string username, string password);
		void Authenticate(CongaCredentials credentials);

		TResponse Execute<TResponse>(BaseRequest request) where TResponse : BaseResponse;
	}
}
