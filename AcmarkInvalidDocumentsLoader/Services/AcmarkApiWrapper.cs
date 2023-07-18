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
using System.Xml.Linq;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class AcmarkApiWrapper
	{
		private static SemaphoreSlim Semaphore = new SemaphoreSlim(10);

		private const string ConstInvalidDocumentsApiPoint = "acm_listinvaliddocuments";

		public AcmarkApiWrapper(string baseUrl)
		{
			//			System.Net.ServicePointManager.ServerCertificateValidationCallback +=
			//(sender, certificate, chain, sslPolicyErrors) => true;

			var options = new RestClientOptions(baseUrl)
			{
				Credentials = new NetworkCredential("acmark\\tkachenko", "wWGwqgov5hkQ"),

				UseDefaultCredentials = false,

				RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,

				MaxTimeout = -1,
			};

			this.Client = new RestClient(options);
		}

		public async Task AddDocumentAsync(string documentNumber, string batch, string documentType, DateTime? invalidationdate)
		{
			await Semaphore.WaitAsync();

			invalidationdate = DateTime.SpecifyKind((DateTime)invalidationdate, DateTimeKind.Local);

			try
			{
				var request = new RestRequest(AcmarkApiWrapper.ConstInvalidDocumentsApiPoint)
				 .AddJsonBody(new
				 {
					 acm_documentnumber = documentNumber,
					 acm_batch = batch,
					 acm_documenttype = documentType,
					 acm_invalidationdate = invalidationdate
				 });

				var responce = await Client.PostAsync(request);

				Console.Write(responce.Content.ToString());
			}

			finally
			{
				Semaphore.Release();
			}

			//return await Client.PostAsync(request);
		}
		public Dictionary<string, ValueListInvalidDocuments> GetAllDocuments()
		{
			var request = new RestRequest(AcmarkApiWrapper.ConstInvalidDocumentsApiPoint);

			var test = Client.Get(request);

			RootListInvalidDocuments entities = JsonSerializer.Deserialize<RootListInvalidDocuments>(test.Content);

			return entities.value.ToDictionary(item => item.acm_listinvaliddocumentid, item => item);
		}

		public async Task RemoveDocumentAsync(string documentId)
		{
			Semaphore.Wait();

			try
			{
				var request = new RestRequest($"{AcmarkApiWrapper.ConstInvalidDocumentsApiPoint}({documentId})");

				var responce = await Client.DeleteAsync(request);

				Console.Write(responce.Content.ToString());
			}

			finally
			{
				Semaphore.Release();
			}
		}

		private RestClient Client
		{
			get;
		}
	}
}
