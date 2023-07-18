using AcmarkInvalidDocumentsLoader.Models;
using AcmarkInvalidDocumentsLoader.Services;
using System.Diagnostics;
using System.Globalization;

namespace AcmarkInvalidDocumentsLoader
{
	internal class Program
	{
		private static Stopwatch PerformanceMonitor = new Stopwatch();
		public static Task[] Tasks { get; set; }

		static async Task Main(string[] args)
		{
			//UNCOMMENT THIS CODE IF YOU WANT TO DELETE ALL INVALID DOCUMENTS
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

			//await DeleteAllInvalidDocuments();


			//UNCOMMENT THIS CODE IF YOU WANT TO DOWNLOAD THE OPVSE BIG FILE for 18 hours THIS FILE HAS 852,000 ELEMENTS
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

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









			PerformanceMonitor.Restart();

			Console.WriteLine("\n\n    ===================================================");
			Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			Console.WriteLine($"         Source: {nameof(ConfigurationLinks.OpDifference)}");
			Console.WriteLine("    ===================================================");

			var entities = await DownloadDifferenceFile(ConfigurationLinks.OpDifference.ToString());

			Dictionary<string, DateTime?> splitPlusFileContent = InitTwoRowsFileDictionary(entities.PlusFileContent);

			UploadFile(splitPlusFileContent, DocumentType.OpWithoutSeries);

			Task.WaitAll(Tasks);

			Dictionary<string, DateTime?> splitMinusFileContent = InitTwoRowsFileDictionary(entities.MinusFileContent);

			foreach (KeyValuePair<string, DateTime?> entity in splitMinusFileContent)
			{
				await DataTransferClient.RemoveContentAsync(entity.Key);
			}

			Console.WriteLine($"         Upload and deleting is over");
			Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			Console.WriteLine("    ===================================================\n\n");










			//UNCOMMENT THIS CODE IF YOU WANT TO DOWNLOAD THE OPVSE BIG FILE for 18-19 hours THIS FILE HAS 857,000 ELEMENTS
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
			//↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

			//Console.WriteLine("\n\n    ===================================================");
			//Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			//Console.WriteLine($"         Source: {nameof(ConfigurationLinks.OpsVseFileLink)}");
			//Console.WriteLine("    ===================================================");

			//var OpVseContent = await DownloadSingleFile(ConfigurationLinks.OpsVseFileLink.ToString());

			//Dictionary<string, ValueListInvalidDocuments> splitOpVseContent = InitThreeRowsFileDictionary(OpVseContent);

			//UploadFile(splitOpVseContent, DocumentType.OpWithSeries);

			//Task.WaitAll(Tasks);

			//Console.WriteLine($"         Upload and deleting is over");
			//Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			//Console.WriteLine("    ===================================================\n\n");

			//PerformanceMonitor.Restart();






			PerformanceMonitor.Restart();

			Console.WriteLine("\n\n    ===================================================");
			Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			Console.WriteLine($"         Source: {nameof(ConfigurationLinks.OpsDifference)}");
			Console.WriteLine("    ===================================================");

			var opsEntities = await DownloadDifferenceFile(ConfigurationLinks.OpsDifference.ToString());

			Dictionary<string, ValueListInvalidDocuments> splitOpPlusFileContent = InitThreeRowsFileDictionary(opsEntities.PlusFileContent);

			UploadFile(splitOpPlusFileContent, DocumentType.OpWithSeries);

			Task.WaitAll(Tasks);

			Dictionary<string, ValueListInvalidDocuments> splitOpMinusFileContent = InitThreeRowsFileDictionary(opsEntities.MinusFileContent);

			foreach (KeyValuePair<string, ValueListInvalidDocuments?> entity in splitOpMinusFileContent)
			{
				await DataTransferClient.RemoveContentAsync(entity.Value.acm_listinvaliddocumentid);
			}

			Task.WaitAll(Tasks);

			Console.WriteLine($"         Upload and deleting is over");
			Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			Console.WriteLine("    ===================================================\n\n");









			PerformanceMonitor.Restart();

			Console.WriteLine("\n\n    ===================================================");
			Console.WriteLine($"         Starting download of '{ConfigurationLinks.MvcInvalidDocumentsWebLink}'");
			Console.WriteLine($"         Source: {nameof(ConfigurationLinks.CdVseFileLink)}");
			Console.WriteLine("    ===================================================");

			var CdVseContent = await DownloadSingleFile(ConfigurationLinks.CdVseFileLink.ToString());

			Dictionary<string, DateTime?> splitCdVseContent = InitTwoRowsFileDictionary(CdVseContent);

			UploadFile(splitCdVseContent, DocumentType.PassportPurple);

			Task.WaitAll(Tasks);

			Console.WriteLine($"         Upload and deleting is over");
			Console.WriteLine($"         Time spent '{PerformanceMonitor.Elapsed}'");
			Console.WriteLine("    ===================================================\n\n");




			
			
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

			for (int i = 0; i < lines.Length - 1; i++)
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
