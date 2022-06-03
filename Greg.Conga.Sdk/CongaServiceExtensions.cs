using Greg.Conga.Sdk.Exceptions;
using Greg.Conga.Sdk.Messages;
using Greg.Conga.Sdk.Messages.Salesforce;
using System;
using System.Collections.Generic;

namespace Greg.Conga.Sdk
{
	public static class CongaServiceExtensions
	{
		public static IReadOnlyCollection<DynamicEntity> RetrieveAll(this ICongaService service, string query, Action<string> log = null)
		{
			return RetrieveAll<DynamicEntity>(service, query, log);
		}

		public static IReadOnlyCollection<T> RetrieveAll<T>(this ICongaService service, string query, Action<string> log = null)
		{
			if (service is null)
			{
				throw new ArgumentNullException(nameof(service), $"{nameof(service)} cannot be null!");
			}

			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentNullException(nameof(query), $"'{nameof(query)}' cannot be null or empty.");
			}

			if (log == null)
			{
				log = s => { };
			}


			var request = new QueryRequest(query);
			var resultList = new List<T>();
			int count = 0;
			do
			{
				try
				{
					log($"Executing query #{++count}");
				}
				catch { };

				var response = service.Execute<QueryResponse<T>>(request);

				if (!string.IsNullOrWhiteSpace(response.ErrorCode))
				{
					throw new SalesforceException(response.ErrorCode, response.Message);
				}

				resultList.AddRange(response.Records);
				request = response.GetNextPage();
			}
			while (request != null);

			return resultList;
		}



		public static QueryResponse RetrieveMultiple(this ICongaService service, string query)
		{
			if (service is null)
			{
				throw new ArgumentNullException(nameof(service), $"{nameof(service)} cannot be null!");
			}

			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentNullException(nameof(query), $"'{nameof(query)}' cannot be null or empty.");
			}

			var request = new QueryRequest(query);
			var response = service.Execute<QueryResponse>(request);

			if (!string.IsNullOrWhiteSpace(response.ErrorCode))
			{
				throw new SalesforceException(response.ErrorCode, response.Message);
			}

			return response;
		}



		public static CreateResponse Create(this ICongaService service, string entityName, object target)
		{
			if (service is null)
			{
				throw new ArgumentNullException(nameof(service), $"{nameof(service)} cannot be null!");
			}

			return service.Execute<CreateResponse>(new CreateRequest(entityName, target));
		}



		public static UpdateResponse Update(this ICongaService service, string entityName, string id, object target)
		{
			if (service is null)
			{
				throw new ArgumentNullException(nameof(service), $"{nameof(service)} cannot be null!");
			}

			return service.Execute<UpdateResponse>(new UpdateRequest(entityName, id, target));
		}



		public static DeleteResponse Delete(this ICongaService service, string entityName, string id)
		{
			if (service is null)
			{
				throw new ArgumentNullException(nameof(service), $"{nameof(service)} cannot be null!");
			}

			return service.Execute<DeleteResponse>(new DeleteRequest(entityName, id));
		}


		public static T Retrieve<T>(this ICongaService service, string entityName, string id, params string[] columns)
		{
			if (service is null)
			{
				throw new ArgumentNullException(nameof(service), $"{nameof(service)} cannot be null!");
			}

			var response = service.Execute<RetrieveResponse>(new RetrieveRequest(entityName, id, columns));
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
				throw new SalesforceException(response.ErrorCode, $"Unable to retrieve data from {entityName}={id}: {response.Message}") { Response = response };

			return response.ToEntity<T>();
		}


		public static bool TryRetrieve<T>(this ICongaService service, string entityName, string id, string[] columns, out T entity)
		{
			if (service is null)
			{
				throw new ArgumentNullException(nameof(service), $"{nameof(service)} cannot be null!");
			}

			entity = default;

			var response = service.Execute<RetrieveResponse>(new RetrieveRequest(entityName, id, columns));
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
				return false;

			entity = response.ToEntity<T>();
			return true;
		}
	}
}
