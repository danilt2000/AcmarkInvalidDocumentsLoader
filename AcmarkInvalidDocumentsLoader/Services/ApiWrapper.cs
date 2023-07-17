using AcmarkInvalidDocumentsLoader.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class ApiWrapper
	{
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

		public void AddInvalidDocumentAsync(string documentNumber, string batch, string documentType, DateTime invalidationdate)
		{
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			var request = new RestRequest("acm_listinvaliddocuments")
				 .AddJsonBody(new
				 {
					 acm_documentnumber = documentNumber,
					 acm_batch = batch,
					 acm_documenttype = documentType,
					 acm_invalidationdate = invalidationdate
				 });
			//var request = new RestRequest("acm_listinvaliddocuments")
			//	 .AddJsonBody(new Dictionary<string, object>
			//	 {
			//		{ "acm_documentnumber", documentNumber },
			//		{ "acm_batch", batch },
			//		{ "acm_documenttype", documentType },
			//		{ "acm_invalidationdate", invalidationdate }
			//	  });
			//request.AddHeader("Cookie", "ReqClientId=96b84521-58c3-46a6-a7cc-d58ff34e2678");
			//request.AddHeader("Content-Type", "application/json");
			var test = Client.Post(request);

			stopWatch.Stop();
			Console.Write("gdfgf");

			//return await Client.PostAsync(request);
		}

		private RestClient Client
		{
			get;
		}
	}
}
