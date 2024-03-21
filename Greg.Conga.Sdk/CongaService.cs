using Greg.Conga.Sdk.Exceptions;
using Greg.Conga.Sdk.Messages;
using Greg.Conga.Sdk.Messages.Salesforce;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Conga.Sdk
{
	public class CongaService : ICongaService
	{
		public CongaService(CongaEndpoint endpoint)
		{
			Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
		}

		public CongaEndpoint Endpoint { get; }

		public LoginResponse Credentials { get; private set; }

		public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(100);



		public void Authenticate(CongaCredentials credentials)
		{
			if (credentials is null)
			{
				throw new ArgumentNullException(nameof(credentials));
			}

			Authenticate(credentials.Username, credentials.Password);
		}

		public void Authenticate(string username, string password)
		{
			var uri = new StringBuilder()
				.Append(this.Endpoint.AuthenticationEndpoint).Append("?grant_type=password")
				.Append("&client_id=").Append(this.Endpoint.AuthenticationClientId)
				.Append("&client_secret=").Append(this.Endpoint.AuthenticationSecret)
				.Append("&username=").Append(username)
				.Append("&password=").Append(password)
				.ToString();


			using (var client = new HttpClient())
			using (var response = client.PostAsync(uri, null).GetAwaiter().GetResult())
			{
				var responseText = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

				var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseText);
				if (loginResponse == null)
					throw new AuthenticationException("Response empty!");


				if (!string.IsNullOrWhiteSpace(loginResponse.Error))
					throw new AuthenticationException($"{loginResponse.Error}: {loginResponse.ErrorDescription}");

				this.Credentials = loginResponse;
			}
		}


		public async Task AuthenticateAsync(CongaCredentials credentials)
		{
			if (credentials is null)
			{
				throw new ArgumentNullException(nameof(credentials));
			}

			await AuthenticateAsync(credentials.Username, credentials.Password);
		}

		public async Task AuthenticateAsync(string username, string password)
		{
			var uri = new StringBuilder()
				.Append(this.Endpoint.AuthenticationEndpoint).Append("?grant_type=password")
				.Append("&client_id=").Append(this.Endpoint.AuthenticationClientId)
				.Append("&client_secret=").Append(this.Endpoint.AuthenticationSecret)
				.Append("&username=").Append(username)
				.Append("&password=").Append(password)
				.ToString();


			using (var client = new HttpClient())
			using (var response = await client.PostAsync(uri, null))
			{
				var responseText = await response.Content.ReadAsStringAsync();

				var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseText);
				if (loginResponse == null)
					throw new AuthenticationException("Response empty!");

				if (!string.IsNullOrWhiteSpace(loginResponse.Error))
					throw new AuthenticationException($"{loginResponse.Error}: {loginResponse.ErrorDescription}");

				this.Credentials = loginResponse;
			}
		}



		public TResponse Execute<TResponse>(BaseRequest request)
			where TResponse : BaseResponse, new()
		{
			if (this.Credentials == null)
				throw new AuthenticationException("Please call Authenticate(...) method first!");


			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
			var uri = request.GetUri(this.Endpoint);


			using (var client = new HttpClient())
			using (var request1 = new HttpRequestMessage(request.Method, uri))
			{
				client.Timeout = Timeout;
				request1.Headers.Add("x-storefront", this.Endpoint.Storefront);
				request1.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.Credentials.AccessToken);
				request.AddAdditionalHeaders(request1);

				if (request.HasBody)
				{
					var contentText = request.ToSerializedObject();
					request1.Content = new StringContent(contentText, Encoding.UTF8, "application/json");
				}


				using (var response = client.SendAsync(request1).GetAwaiter().GetResult())
				{
					try
					{
						var congaResponse = GetCongaResponse<TResponse>(response, settings);
						
						if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent)
						{
							throw new SdkException(request, congaResponse, congaResponse.StatusDescription);
						}
						return congaResponse;
					}
					catch (HttpRequestException ex)
					{
						var innerResponse = GetCongaResponse<TResponse>(response, settings);
						throw new SdkException(request, innerResponse, ex.Message);
					}
				}
			}
		}


		public async Task<TResponse> ExecuteAsync<TResponse>(BaseRequest request)
			where TResponse : BaseResponse, new()
		{
			if (this.Credentials == null)
				throw new AuthenticationException("Please call Authenticate(...) method first!");


			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
			var uri = request.GetUri(this.Endpoint);


			using (var client = new HttpClient())
			using (var request1 = new HttpRequestMessage(request.Method, uri))
			{
				client.Timeout = Timeout;
				request1.Headers.Add("x-storefront", this.Endpoint.Storefront);
				request1.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.Credentials.AccessToken);

				if (request.HasBody)
				{
					request1.Content = new StringContent(request.ToSerializedObject(), Encoding.UTF8, "application/json");
				}


				using (var response = await client.SendAsync(request1))
				{
					try
					{
						var congaResponse = await GetCongaResponseAsync<TResponse>(response, settings);

						if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent)
						{
							throw new SdkException(request, congaResponse, congaResponse.StatusDescription);
						}
						return congaResponse;
					}
					catch (HttpRequestException ex)
					{
						var innerResponse = await GetCongaResponseAsync<TResponse>(response, settings);
						throw new SdkException(request, innerResponse, ex.Message);
					}
				}
			}
		}


		private static async Task<TResponse> GetCongaResponseAsync<TResponse>(HttpResponseMessage webResponse, JsonSerializerSettings settings)
				where TResponse : BaseResponse, new()
		{
			string responseText = null;
			try
			{
				responseText = await webResponse.Content.ReadAsStringAsync();

			}
			catch (ObjectDisposedException)
			{
				// may happen if the server returned no response
			}
			return ParseResponseText<TResponse>(webResponse, settings, responseText);
		}

		private static TResponse GetCongaResponse<TResponse>(HttpResponseMessage webResponse, JsonSerializerSettings settings)
				where TResponse : BaseResponse, new()
		{
			string responseText = null;
			try
			{
				responseText = webResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}
			catch (ObjectDisposedException)
			{
				// may happen if the server returned no response
			}
			return ParseResponseText<TResponse>(webResponse, settings, responseText);
		}


		private static TResponse ParseResponseText<TResponse>(HttpResponseMessage webResponse, JsonSerializerSettings settings, string responseText) 
			where TResponse : BaseResponse, new()
		{
			if (string.IsNullOrWhiteSpace(responseText))
			{
				var congaResponse = new TResponse();
				congaResponse.StatusCode = webResponse.StatusCode;
				congaResponse.StatusDescription = webResponse.ReasonPhrase;
				return congaResponse;
			}


			// the response is a singl object
			if (!responseText.StartsWith("[", StringComparison.Ordinal))
			{
				var congaResponse = JsonConvert.DeserializeObject<TResponse>(responseText, settings);
				congaResponse.Raw = responseText;
				congaResponse.StatusCode = webResponse.StatusCode;
				congaResponse.StatusDescription = webResponse.ReasonPhrase;
				return congaResponse;
			}



			// the response is an array
			var type = typeof(TResponse).MakeArrayType();
			var congaResponseArray = (TResponse[])JsonConvert.DeserializeObject(responseText, type, settings);



			// the response array is not empty
			if (congaResponseArray?.Length > 0)
			{
				var congaResponse = congaResponseArray[0];
				congaResponse.Raw = responseText;
				congaResponse.StatusCode = webResponse.StatusCode;
				congaResponse.StatusDescription = webResponse.ReasonPhrase;
				return congaResponse;
			}



			// the response array is empty
			var congaResponse1 = Activator.CreateInstance<TResponse>();
			congaResponse1.Raw = responseText;
			congaResponse1.StatusCode = webResponse.StatusCode;
			congaResponse1.StatusDescription = webResponse.ReasonPhrase;
			return congaResponse1;
		}
	}
}
