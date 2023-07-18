using ICSharpCode.SharpZipLib.Zip;
using System.Text;
using System.Configuration;
using AcmarkInvalidDocumentsLoader.Services;
using Quartz.Impl;
using Quartz;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Security;
using AcmarkInvalidDocumentsLoader.Models;
using System.Diagnostics;
using System;
using Quartz.Util;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcmarkInvalidDocumentsLoader
{
	internal class Program
	{
		private static Stopwatch PerformanceMonitor = new Stopwatch();
		public static Task[] Tasks { get; set; }

		static async Task Main(string[] args)
		{


			//PerformanceMonitor.Start();

			//Console.WriteLine("\n\n    ===================================================");
			//Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			//Console.WriteLine($"         Source: {nameof(ConfigurationLinks.OpVseFileLink)}");
			//Console.WriteLine("    ===================================================");

			//var OpVseContent = await DownloadSingleFile(ConfigurationLinks.OpVseFileLink.ToString());

			//Dictionary<string, DateTime?> splitOpVseContent = InitTwoRowsFileDictionary(OpVseContent);

			//UploadFile(splitOpVseContent, DocumentType.OpWithoutSeries);

			//Task.WaitAll(Tasks);

			//Console.WriteLine($"         Upload is over");
			//Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			//Console.WriteLine("    ===================================================\n\n");


















			//PerformanceMonitor.Restart();

			//Console.WriteLine("\n\n    ===================================================");
			//Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			//Console.WriteLine($"         Source: {nameof(ConfigurationLinks.OpDifference)}");
			//Console.WriteLine("    ===================================================");

			//var entities = await DownloadDifferenceFile(ConfigurationLinks.OpDifference.ToString());

			//Dictionary<string, DateTime?> splitPlusFileContent = InitTwoRowsFileDictionary(entities.PlusFileContent);

			//UploadFile(splitPlusFileContent, DocumentType.OpWithoutSeries);

			//Task.WaitAll(Tasks);

			//Dictionary<string, DateTime?> splitMinusFileContent = InitTwoRowsFileDictionary(entities.MinusFileContent);

			//foreach (KeyValuePair<string, DateTime?> entity in splitMinusFileContent)
			//{
			//	await DataTransferClient.RemoveContentAsync(entity.Key);
			//}

			//Console.WriteLine($"         Upload and deleting is over");
			//Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			//Console.WriteLine("    ===================================================\n\n");






			await DeleteAllInvalidDocuments();






			//Console.WriteLine("\n\n    ===================================================");
			//Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			//Console.WriteLine($"         Source: {nameof(ConfigurationLinks.OpsVseFileLink)}");
			//Console.WriteLine("    ===================================================");

			//var OpVseContent = await DownloadSingleFile(ConfigurationLinks.OpsVseFileLink.ToString());

			//Dictionary<string, ValueListInvalidDocuments> splitOpVseContent = InitThreeRowsFileDictionary(OpVseContent);

			//UploadFile(splitOpVseContent, DocumentType.OpWithSeries);

			//Task.WaitAll(Tasks);

			//Console.WriteLine($"         Upload is over");
			//Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			//Console.WriteLine("    ===================================================\n\n");

			//PerformanceMonitor.Restart();







			//Console.WriteLine("\n\n    ===================================================");
			//Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			//Console.WriteLine($"         Source: {nameof(ConfigurationLinks.OpsDifference)}");
			//Console.WriteLine("    ===================================================");

			//var entities = await DownloadDifferenceFile(ConfigurationLinks.OpsDifference.ToString());

			//Dictionary<string, ValueListInvalidDocuments> splitOpPlusFileContent = InitThreeRowsFileDictionary(entities.PlusFileContent);

			//UploadFile(splitOpPlusFileContent, DocumentType.OpWithSeries);

			//Task.WaitAll(Tasks);

			//Dictionary<string, ValueListInvalidDocuments> splitOpMinusFileContent = InitThreeRowsFileDictionary(entities.MinusFileContent);

			//foreach (KeyValuePair<string, ValueListInvalidDocuments?> entity in splitOpMinusFileContent)
			//{
			//	await DataTransferClient.RemoveContentAsync(entity.Value.acm_listinvaliddocumentid);
			//}

			//Task.WaitAll(Tasks);

			//Console.WriteLine($"         Upload is over");
			//Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			//Console.WriteLine("    ===================================================\n\n");

			//PerformanceMonitor.Restart();



			//PerformanceMonitor.Start();

			//Console.WriteLine("\n\n    ===================================================");
			//Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			//Console.WriteLine($"         Source: {nameof(ConfigurationLinks.CdVseFileLink)}");
			//Console.WriteLine("    ===================================================");

			//var CdVseContent = await DownloadSingleFile(ConfigurationLinks.CdVseFileLink.ToString());

			//Dictionary<string, DateTime?> splitCdVseContent = InitTwoRowsFileDictionary(CdVseContent);

			//UploadFile(splitCdVseContent, DocumentType.PassportPurple);

			//Task.WaitAll(Tasks);

			//Console.WriteLine($"         Upload is over");
			//Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			//Console.WriteLine("    ===================================================\n\n");




			PerformanceMonitor.Restart();

			Console.WriteLine("\n\n    ===================================================");
			Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			Console.WriteLine($"         Source: {nameof(ConfigurationLinks.CdDifference)}");
			Console.WriteLine("    ===================================================");

			var entitiesCd = await DownloadDifferenceFile(ConfigurationLinks.CdDifference.ToString());

			Dictionary<string, DateTime?> splitCdPlusFileContent = InitTwoRowsFileDictionary(entitiesCd.PlusFileContent);

			UploadFile(splitCdPlusFileContent, DocumentType.PassportPurple);

			Task.WaitAll(Tasks);

			Dictionary<string, DateTime?> splitCdMinusFileContent = InitTwoRowsFileDictionary(entitiesCd.MinusFileContent);

			foreach (KeyValuePair<string, DateTime?> entity in splitCdMinusFileContent)
			{
				await DataTransferClient.RemoveContentAsync(entity.Key);
			}

			Console.WriteLine($"         Upload and deleting is over");
			Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			Console.WriteLine("    ===================================================\n\n");



			//var entities = acmarkDataTransferClient.ApiWrapper.GetAllDocuments();

			//Task[] tasks = new Task[entities.Count];

			////Task[] tasks = new Task[100];
			//foreach (KeyValuePair<string, ValueListInvalidDocuments> entity in entities)
			//{
			//	await acmarkDataTransferClient.ApiWrapper.RemoveDocumentAsync(entity.Key);

			//	// 'entry.Key' - ключ текущего элемента
			//	// 'entry.Value' - значение текущего элемента
			//	//	//tasks[i] = Task.Run(() => acmarkDataTransferClient.ApiWrapper.RemoveDocumentAsync(entities.value[i].acm_listinvaliddocumentid));

			//	// Здесь можно добавить код для работы с ключом и значением.
			//}
			//for (int i = 0; i < entities.value.Count; i++)
			//{
			//	//tasks[i] = Task.Run(() => acmarkDataTransferClient.ApiWrapper.RemoveDocumentAsync(entities.value[i].acm_listinvaliddocumentid));

			//	//await acmarkDataTransferClient.ApiWrapper.RemoveDocumentAsync(entities.value[i].acm_listinvaliddocumentid);

			//}


			//for (int i = 0; i < 100; i++)
			//{

			//	//await acmarkDataTransferClient.UploadContentAsync(RandomString(6), "AAAA", DocumentType.OpWithSeries, DateTime.Now);
			//	tasks[i] = Task.Run(() => acmarkDataTransferClient.UploadContentAsync(RandomString(6), "AAAA", DocumentType.OpWithSeries, DateTime.Now));
			//}

			//Task.WaitAll(tasks);




			//Console.Write("gdfgf");


			//var neco = ConfigurationManager.AppSettings["MvcInvalidDocumentsWebLink"];


			//// Grab the Scheduler instance from the Factory 
			//try
			//{
			//	var schedulerFactory = new StdSchedulerFactory();
			//	var scheduler = await schedulerFactory.GetScheduler();

			//	// Start the scheduler
			//	await scheduler.Start();

			//	// Define the job
			//	var job = JobBuilder.Create<HelloJob>()
			//	    .WithIdentity("myJob", "myGroup")
			//	    .Build();

			//	// Define the trigger to run every 5 seconds
			//	var trigger = TriggerBuilder.Create()
			//		 .WithIdentity("midnightTrigger", "myGroup")
			//		 .WithDailyTimeIntervalSchedule(x => x
			//		.OnEveryDay()
			//		.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 5))
			//		  )
			//		   .Build();

			//	// Schedule the job with the trigger
			//	await scheduler.ScheduleJob(job, trigger);

			//	// Wait for the scheduled jobs to execute
			//	await Task.Delay(TimeSpan.FromMinutes(1));

			//	Console.WriteLine();

			//	// Shutdown the scheduler
			//	await scheduler.Shutdown();
			//}
			//catch (SchedulerException se)
			//{
			//	Console.WriteLine(se);
			//}

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

		private static async Task DeleteAllInvalidDocuments()
		{
			var entities = DataTransferClient.GetAllDocuments();

			foreach (KeyValuePair<string, ValueListInvalidDocuments> entity in entities)
			{
				await DataTransferClient.RemoveContentAsync(entity.Key);
			}
		}

		public static void UploadFile(Dictionary<string, DateTime?> splitContent, string configuration)
		{
			int index = 0;

			Tasks = new Task[splitContent.Count];

			foreach (KeyValuePair<string, DateTime?> entity in splitContent)
			{
				Tasks[index] = Task.Run(() => DataTransferClient.UploadContentAsync(entity.Key, string.Empty, configuration, entity.Value));

				index++;
			}
		}
		public static void UploadFile(Dictionary<string, ValueListInvalidDocuments> splitContent, string configuration)
		{
			int index = 0;

			Tasks = new Task[splitContent.Count];

			foreach (KeyValuePair<string, ValueListInvalidDocuments> entity in splitContent)
			{
				Tasks[index] = Task.Run(() => DataTransferClient.UploadContentAsync(entity.Value.acm_documentnumber, entity.Value.acm_batch, configuration, entity.Value.acm_invalidationdate));

				index++;
			}
		}

		public static async Task<string> DownloadSingleFile(string configuration)
		{
			var FileText = await DownloadService.DownloadFileContentAsync(configuration);

			return FileText;
		}

		public static async Task<(string? PlusFileContent, string? MinusFileContent)> DownloadDifferenceFile(string configuration)
		{
			var DifferenceFileText = await DownloadService.DownloadFileContentAsync(configuration, true);

			return (DifferenceFileText.PlusFileContent, DifferenceFileText.MinusFileContent);
		}

		public static Dictionary<string, DateTime?> InitTwoRowsFileDictionary(string FileContent)
		{
			var lines = FileContent.Split("\r\n");

			Dictionary<string, DateTime?> splitFileContent = new Dictionary<string, DateTime?>();

			for (int i = 0; i < lines.Length-1; i++)
			{
				var parts = lines[i].Trim().Split(new[] { ';' }, 2);

				string key = parts[0].Trim();
				DateTime? value = null;

				if (parts.Length > 1)
				{
					DateTime date;
					if (DateTime.TryParseExact(parts[1].Trim(), "d.M.yyyy",
					    CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
					{
						value = date;
					}
				}

				splitFileContent.Add(key, value);
			}

			return splitFileContent;
		}
		public static Dictionary<string, ValueListInvalidDocuments> InitThreeRowsFileDictionary(string FileContent)
		{
			var splitFileContent = new Dictionary<string, ValueListInvalidDocuments>();

			var lines = FileContent.Split("\r\n");

			for (int i = 0; i < lines.Length - 1; i++)
			{
				var parts = lines[i].Split(';');
				var document = new ValueListInvalidDocuments
				{
					acm_documentnumber = parts[0],
					acm_batch = parts.Length > 1 ? parts[1] : null,
				};

				if (parts.Length > 2 && DateTime.TryParseExact(parts[2].Trim(), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
				{
					document.acm_invalidationdate = DateTime.ParseExact(parts[2].Trim(), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
				}
				else
				{
					document.acm_invalidationdate = DateTime.MinValue;
				}

				splitFileContent.Add(i.ToString(), document);
			}

			return splitFileContent;
		}


		//Dictionary<string, DateTime?> splitFileContent = FileContent
		//				.Split("\r\n")
		//				.Select(item => item.Trim().Split(new[] { ';' }, 2))
		//				.ToDictionary(parts => parts[0].Trim(),
		//				parts =>
		//				{
		//					DateTime date;
		//					return parts.Length > 1 && DateTime.TryParseExact(parts[1].Trim(), "d.M.yyyy",
		//					CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ? date : (DateTime?)null;
		//				});

		static MvcrDownloader DownloadService
		{
			get
			{
				_DownloadService ??= new MvcrDownloader(ConfigurationLinks.MvcInvalidDocumentsWebLink);
				return _DownloadService;
			}
		}

		private static MvcrDownloader? _DownloadService;

		static AcmarkDataTransferClient DataTransferClient
		{
			get
			{
				_DataTransferClient ??= new AcmarkDataTransferClient(ConfigurationLinks.DevAcmarkEuApiLink);
				return _DataTransferClient;
			}
		}

		private static AcmarkDataTransferClient? _DataTransferClient;

	}
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
