using Greg.Conga.Sdk.Exceptions;
using Greg.Conga.Sdk.Messages;
using Greg.Conga.Sdk.Messages.Salesforce;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

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


			var request = WebRequest.Create(uri);
			request.Method = "POST";
			using (var response = request.GetResponse())
			using (var reader = new StreamReader(response.GetResponseStream()))
			{
				var responseText = reader.ReadToEnd();
				var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseText);

				if (loginResponse == null)
					throw new AuthenticationException("Response empty!");


				if (!string.IsNullOrWhiteSpace(loginResponse.Error))
					throw new AuthenticationException($"{loginResponse.Error}: {loginResponse.ErrorDescription}");

				this.Credentials = loginResponse;
			}
		}



		public TResponse Execute<TResponse>(BaseRequest request)
			where TResponse : BaseResponse
		{
			if (this.Credentials == null)
				throw new AuthenticationException("Please call Authenticate(...) method first!");


			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			};
			var uri = request.GetUri(this.Endpoint);

			var webRequest = WebRequest.Create(uri);
			webRequest.Method = request.Method;
			webRequest.Headers.Add("x-storefront", this.Endpoint.Storefront);
			webRequest.ContentType = "application/json";
			webRequest.Headers.Add("Authorization", "Bearer " + this.Credentials.AccessToken);

			if (request.HasBody)
			{
				using (var writer = new StreamWriter(webRequest.GetRequestStream()))
				{
					var requestText = request.ToSerializedObject();
					writer.Write(requestText);
					writer.Flush();
				}
			}

			try
			{
				using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
				{
					return GetCongaResponse<TResponse>(webResponse, settings);
				}
			}
			catch (WebException ex)
			{
				using (var webResponse = (HttpWebResponse)ex.Response)
				{
					return GetCongaResponse<TResponse>(webResponse, settings);
				}
			}
		}



		private TResponse GetCongaResponse<TResponse>(HttpWebResponse webResponse, JsonSerializerSettings settings)
				where TResponse : BaseResponse
		{
			using (var reader = new StreamReader(webResponse.GetResponseStream()))
			{
				var responseText = reader.ReadToEnd();
				// the response is a singl object
				if (!responseText.StartsWith("["))
				{
					var congaResponse = JsonConvert.DeserializeObject<TResponse>(responseText, settings);
					congaResponse.Raw = responseText;
					congaResponse.StatusCode = webResponse.StatusCode;
					congaResponse.StatusDescription = webResponse.StatusDescription;
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
					congaResponse.StatusDescription = webResponse.StatusDescription;
					return congaResponse;
				}



				// the response array is empty
				var congaResponse1 = Activator.CreateInstance<TResponse>();
				congaResponse1.Raw = responseText;
				congaResponse1.StatusCode = webResponse.StatusCode;
				congaResponse1.StatusDescription = webResponse.StatusDescription;
				return congaResponse1;
			}
		}
	}
}
