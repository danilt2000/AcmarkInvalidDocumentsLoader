using AcmarkInvalidDocumentsLoader.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class AcmarkApiWrapper
	{
		private static SemaphoreSlim Semaphore = new SemaphoreSlim(10);

		private const string ConstInvalidDocumentsApiPoint = "acm_listinvaliddocuments";

		public AcmarkApiWrapper(string baseUrl)
		{
			var options = new RestClientOptions(baseUrl)
			{
				Credentials = new NetworkCredential(ConfigurationManager.AppSettings["AcmarkLogin"], ConfigurationManager.AppSettings["AcmarkPassword"]),

				UseDefaultCredentials = false,

				RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,

				MaxTimeout = -1,
			};

			this.Client = new RestClient(options);
		}

		public async Task AddDocumentAsync(string documentNumber, string batch, string documentType, DateTime? invalidationdate)
		{
			await Semaphore.WaitAsync();

			DateTime? selectedDate = DateTime.SpecifyKind((DateTime)invalidationdate, DateTimeKind.Local);

			if (invalidationdate == DateTime.MinValue)
				selectedDate = null;

			try
			{
				var request = new RestRequest(AcmarkApiWrapper.ConstInvalidDocumentsApiPoint)
				 .AddJsonBody(new
				 {
					 acm_documentnumber = documentNumber,
					 acm_batch = batch,
					 acm_documenttype = documentType,
					 acm_invalidationdate = selectedDate
				 });

				var responce = await Client.PostAsync(request);

				Console.Write(responce.Content.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to add element with document number: {documentNumber}. Error: {ex.Message}");

				//ERROR LOG TO ACMARK API

				Semaphore.Release();
			}
			finally
			{
				Semaphore.Release();
			}
		}
		public Dictionary<string, ValueListInvalidDocuments> GetAllDocuments()
		{
			RootListInvalidDocuments entities = null;
			try
			{
				var request = new RestRequest(AcmarkApiWrapper.ConstInvalidDocumentsApiPoint);

				var responce = Client.Get(request);

				entities = JsonSerializer.Deserialize<RootListInvalidDocuments>(responce.Content);
			}

			catch (Exception ex)
			{
				Console.WriteLine($"Failed to get all elements. Error: {ex.Message}");

				//ERROR LOG TO ACMARK API
			}

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
			catch (Exception ex)
			{
				Console.WriteLine($"This item was not found {documentId}, please check if this item exists in the database. Error: {ex.Message}");

				//ERROR LOG TO ACMARK API

				Semaphore.Release();
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
