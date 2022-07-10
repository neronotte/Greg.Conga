using Greg.Conga.Sdk.Messages;
using System.Threading.Tasks;

namespace Greg.Conga.Sdk
{
	public interface ICongaService
	{
		void Authenticate(string username, string password);
		void Authenticate(CongaCredentials credentials);
		Task AuthenticateAsync(string username, string password);
		Task AuthenticateAsync(CongaCredentials credentials);

		TResponse Execute<TResponse>(BaseRequest request) where TResponse : BaseResponse, new();

		Task<TResponse> ExecuteAsync<TResponse>(BaseRequest request) where TResponse : BaseResponse, new();
	}
}
