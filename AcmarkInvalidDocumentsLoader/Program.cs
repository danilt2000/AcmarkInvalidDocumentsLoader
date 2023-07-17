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
using System.Diagnostics;
using System;

namespace AcmarkInvalidDocumentsLoader
{
	internal class Program
	{
		private static Random random = new Random();

		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
			    .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		static async Task Main(string[] args)
		{



			Stopwatch stopWatch = new Stopwatch();




			stopWatch.Start();


			AcmarkDataTransferClient acmarkDataTransferClient = new AcmarkDataTransferClient(ConfigurationLinks.DevAcmarkEuApiLink);


			var entities = acmarkDataTransferClient.ApiWrapper.GetAllDocuments();

			Task[] tasks = new Task[entities.value.Count];

			//Task[] tasks = new Task[100];

			for (int i = 0; i < entities.value.Count; i++)
			{
				//tasks[i] = Task.Run(() => acmarkDataTransferClient.ApiWrapper.RemoveDocumentAsync(entities.value[i].acm_listinvaliddocumentid));

				await acmarkDataTransferClient.ApiWrapper.RemoveDocumentAsync(entities.value[i].acm_listinvaliddocumentid);

			}


			//for (int i = 0; i < 100; i++)
			//{

			//	//await acmarkDataTransferClient.UploadContentAsync(RandomString(6), "AAAA", DocumentType.OpWithSeries, DateTime.Now);
			//	tasks[i] = Task.Run(() => acmarkDataTransferClient.UploadContentAsync(RandomString(6), "AAAA", DocumentType.OpWithSeries, DateTime.Now));
			//}

			//Task.WaitAll(tasks);



			stopWatch.Stop();

			Console.Write("gdfgf");


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