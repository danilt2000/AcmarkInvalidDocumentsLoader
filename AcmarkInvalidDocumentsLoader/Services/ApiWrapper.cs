using AcmarkInvalidDocumentsLoader.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class ApiWrapper
	{
		public ApiWrapper(string baseUrl)
		{
			var options = new RestClientOptions(baseUrl)
			{
				Credentials = new NetworkCredential("acmark\\tkachenko", "wWGwqgov5hkQ"),
				UseDefaultCredentials = false,
				MaxTimeout = -1,
			};

			this.Client = new RestClient(options);
		}

		public async Task<RestResponse> AddInvalidDocumentAsync(string documentNumber, string batch, string documentType, DateTime invalidationdate)
		{
			var request = new RestRequest("acm_listinvaliddocuments")
				 .AddJsonBody(new
				 {
					 acm_documentnumber = documentNumber,
					 acm_batch = batch,
					 acm_documenttype = documentType,
					 acm_invalidationdate = invalidationdate
				 });

			var test = Client.Post(request);

			return await Client.PostAsync(request);
		}

		private RestClient Client
		{
			get;
		}
	}
}
