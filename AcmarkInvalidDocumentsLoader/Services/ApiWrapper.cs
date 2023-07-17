using AcmarkInvalidDocumentsLoader.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class ApiWrapper
	{
		private static SemaphoreSlim semaphore = new SemaphoreSlim(5);
		public ApiWrapper(string baseUrl)
		{
			System.Net.ServicePointManager.ServerCertificateValidationCallback +=
(sender, certificate, chain, sslPolicyErrors) => true;
			//var handler = new HttpClientHandler()
			//{
			//	ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
			//	SslProtocols = SslProtocols.Tls12
			//};
			//var credentials = new NetworkCredential("acmark\\tkachenko", "wWGwqgov5hkQ",);

			var options = new RestClientOptions(baseUrl)
			{
				Credentials = new NetworkCredential("acmark\\tkachenko", "wWGwqgov5hkQ"),
				UseDefaultCredentials = false,
				//HttpMessageHandler = handler,

				RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,

				MaxTimeout = -1,
			};

			this.Client = new RestClient(options);
		}

		public async Task AddDocumentAsync(string documentNumber, string batch, string documentType, DateTime invalidationdate)
		{
			await semaphore.WaitAsync();

			try
			{
				var request = new RestRequest("acm_listinvaliddocuments")
				 .AddJsonBody(new
				 {
					 acm_documentnumber = documentNumber,
					 acm_batch = batch,
					 acm_documenttype = documentType,
					 acm_invalidationdate = invalidationdate
				 });

				var test = await Client.PostAsync(request);
			}
			finally
			{
				semaphore.Release();
			}

			//return await Client.PostAsync(request);
		}
		public RootListInvalidDocuments? GetAllDocuments()
		{
			var request = new RestRequest("acm_listinvaliddocuments");

			var test = Client.Get(request);

			RootListInvalidDocuments entities = JsonSerializer.Deserialize<RootListInvalidDocuments>(test.Content);

			return entities;
		}


		private RestClient Client
		{
			get;
		}
	}
}
