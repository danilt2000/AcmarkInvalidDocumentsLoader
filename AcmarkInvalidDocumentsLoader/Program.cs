using ICSharpCode.SharpZipLib.Zip;
using System.Text;
using System.Configuration;
using AcmarkInvalidDocumentsLoader.Services;
using Quartz.Impl;
using Quartz;
using AcmarkService;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Security;
using AcmarkInvalidDocumentsLoader.Models;

namespace AcmarkInvalidDocumentsLoader
{
	internal class Program
	{


		static async Task Main(string[] args)
		{

			AcmarkDataTransferClient acmarkDataTransferClient = new AcmarkDataTransferClient(ConfigurationLinks.MvcInvalidDocumentsWebLink);

			var responce = acmarkDataTransferClient.UploadContentAsync("4242", "41421", DocumentType.OpWithSeries, DateTime.Now);
			//ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
			//{
			//	return true;
			//};

			//System.Net.ServicePointManager.ServerCertificateValidationCallback +=
			// (se, cert, chain, sslerror) =>
			// {
			//	 return true;
			// };
			//HttpClientHandler clientHandler = new HttpClientHandler();
			//clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
			//{
			//	return true;
			//};

			////var binding = new WSHttpBinding();
			////binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
			////binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;

			//var binding = new CustomBinding();

			//binding.Elements.Add(new TextMessageEncodingBindingElement());

			//binding.Elements.Add(new HttpsTransportBindingElement());

			//var endpoint = new EndpointAddress("https://dev.acmark.eu:5555/ACMARK/XRMServices/2011/Organization.svc?wsdl");

			//var basicHttpBinding = new BasicHttpBinding(
			//      BasicHttpSecurityMode.TransportWithMessageCredential);
			//basicHttpBinding.Security.Message.ClientCredentialType =
			//				     BasicHttpMessageCredentialType.UserName;

			//var client = new OrganizationServiceClient(binding, endpoint);

			//client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
			//new X509ServiceCertificateAuthentication()
			//{
			//	CertificateValidationMode = X509CertificateValidationMode.None,
			//	RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
			//};

			//client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

			//client.ClientCredentials.UserName.UserName = "acmark\\tkachenko";

			//client.ClientCredentials.UserName.Password = "wWGwqgov5hkQ";

			//client.ClientCredentials.Windows.ClientCredential.UserName = "acmark\\tkachenko";

			//client.ClientCredentials.Windows.ClientCredential.Password = "wWGwqgov5hkQ";

			//client.Open();

			//Entity invalidDocument = new Entity();

			//invalidDocument.Attributes = new AttributeCollection();

			//invalidDocument.LogicalName = "acm_listinvaliddocument";

			//KeyValuePair<string, object> keyValuePairInvalidDate = new KeyValuePair<string, object>("acm_invalidationdate", DateTime.Now.ToString());

			//KeyValuePair<string, object> keyValuePairDocumentNumber = new KeyValuePair<string, object>("acm_documentnumber", 412);

			//invalidDocument.Attributes.Add(keyValuePairInvalidDate);

			//invalidDocument.Attributes.Add(keyValuePairDocumentNumber);

			//invalidDocument.Id = Guid.NewGuid();

			//client.Create(invalidDocument);
			//client.Close();



			var neco = ConfigurationManager.AppSettings["MvcInvalidDocumentsWebLink"];


			// Grab the Scheduler instance from the Factory 
			try
			{
				var schedulerFactory = new StdSchedulerFactory();
				var scheduler = await schedulerFactory.GetScheduler();

				// Start the scheduler
				await scheduler.Start();

				// Define the job
				var job = JobBuilder.Create<HelloJob>()
				    .WithIdentity("myJob", "myGroup")
				    .Build();

				// Define the trigger to run every 5 seconds
				var trigger = TriggerBuilder.Create()
					 .WithIdentity("midnightTrigger", "myGroup")
					 .WithDailyTimeIntervalSchedule(x => x
					.OnEveryDay()
					.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 5))
					  )
					   .Build();

				// Schedule the job with the trigger
				await scheduler.ScheduleJob(job, trigger);

				// Wait for the scheduled jobs to execute
				await Task.Delay(TimeSpan.FromMinutes(1));

				Console.WriteLine();

				// Shutdown the scheduler
				await scheduler.Shutdown();
			}
			catch (SchedulerException se)
			{
				Console.WriteLine(se);
			}

			// and start it off
			//scheduler.Start();

			//// define the job and tie it to our HelloJob class
			//IJobDetail job = JobBuilder.Create<HelloJob>()
			//    .WithIdentity("job1", "group1")
			//    .Build();

			//// Trigger the job to run now, and then repeat every 10 seconds
			//ITrigger trigger = TriggerBuilder.Create()
			//    .WithIdentity("trigger1", "group1")
			//    .StartNow()
			//    .WithSimpleSchedule(x => x
			//	.WithIntervalInSeconds(10)
			//	.RepeatForever())
			//    .Build();

			//// Tell Quartz to schedule the job using our trigger
			//scheduler.ScheduleJob(job, trigger);

			//// some sleep to show what's happening
			//Thread.Sleep(TimeSpan.FromSeconds(60));

			//// and last shut down the scheduler when you are ready to close your program
			//scheduler.Shutdown();

			//string ConstMvcInvalidDocumentLink = ConfigurationManager.AppSettings["MvcInvalidDocumentsWebLink"];







			//var OpVseFileText = await DownloadService.DownloadFileContentAsync($"{OpVseFileLink}");










			//string mvcInvalidDocumentsWebLink = ConfigurationManager.AppSettings["MvcInvalidDocumentsWebLink"];

			//// Получение значения ключа "OpVseFileLink"
			//string opVseFileLink = ConfigurationManager.AppSettings["OpVseFileLink"];

			//// Получение значения ключа "OpDifference"
			//string opDifference = ConfigurationManager.AppSettings["OpDifference"];

			//// Получение значения ключа "OpsVseFileLink"
			//string opsVseFileLink = ConfigurationManager.AppSettings["OpsVseFileLink"];

			//// Получение значения ключа "OpsDifference"
			//string opsDifference = ConfigurationManager.AppSettings["OpsDifference"];

			//// Получение значения ключа "CdVseFileLink"
			//string cdVseFileLink = ConfigurationManager.AppSettings["CdVseFileLink"];

			//// Получение значения ключа "CdDifference"
			//string cdDifference = ConfigurationManager.AppSettings["CdDifference"];

			//Console.WriteLine(MvcLink);
		}

		static MvcrDownloader DownloadService
		{
			get
			{
				_DownloadService ??= new MvcrDownloader(ConfigurationLinks.MvcInvalidDocumentsWebLink);
				return _DownloadService;
			}
		}

		private static MvcrDownloader? _DownloadService;


	}
	public class HelloJob : IJob
	{

		public void Execute(IJobExecutionContext context)
		{
			Console.WriteLine("HelloJob is executing.");
		}

		Task IJob.Execute(IJobExecutionContext context)
		{
			return null;
		}
	}
}