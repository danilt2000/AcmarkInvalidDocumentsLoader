using AcmarkInvalidDocumentsLoader.Interfaces;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class MvcrDownloader : IDownloadService
	{
		public string MvcInvalidDocumentsWebLink { get; set; }
		public MvcrDownloader(string mvcInvalidDocumentsWebLink)
		{
			MvcInvalidDocumentsWebLink = mvcInvalidDocumentsWebLink;
		}

		public async Task<string> DownloadFileContentAsync(string fileDocumentHref)
		{
			var fileContent = await DownloadFileContentAsync(fileDocumentHref, false);

			if (!string.IsNullOrWhiteSpace(fileContent.PlusFileContent) && !string.IsNullOrEmpty(fileContent.PlusFileContent))
				return fileContent.PlusFileContent;

			else
				ErrorLog(fileDocumentHref);

			return string.Empty;
		}

		private void ErrorLog(string fileDocumentHref)
		{
			Console.WriteLine($"Failed failed to download in {nameof(MvcrDownloader)} file from {MvcInvalidDocumentsWebLink}{fileDocumentHref}");//error logging to the ACMARK Api service 

			throw new HttpRequestException();
		}

		private async Task<(string? PlusFileContent, string? MinusFileContent)> DownloadFileContentAsync(string fileDocumentHref, bool isDownloadDifferenceFiles)
		{
			string? plusFileContent = null;

			string? minusFileContent = null;

			string fileDocumentLink = MvcInvalidDocumentsWebLink + fileDocumentHref;

			using (var client = new HttpClient())
			{
				var response = await client.GetAsync(fileDocumentLink);
				response.EnsureSuccessStatusCode();

				var fileBytes = await response.Content.ReadAsByteArrayAsync();

				using (var memoryStream = new MemoryStream(fileBytes))
				using (var zipInputStream = new ZipInputStream(memoryStream))
				{
					int index = 0;

					ZipEntry zipEntry;

					while ((zipEntry = zipInputStream.GetNextEntry()) != null)
					{

						if (isDownloadDifferenceFiles && index == 0)
							plusFileContent = await ReadZipStream(zipInputStream);

						if (isDownloadDifferenceFiles && index == 1)
							minusFileContent = await ReadZipStream(zipInputStream);

						if (!isDownloadDifferenceFiles)
							plusFileContent = await ReadZipStream(zipInputStream);

						index++;
					}
				}
			}

			if (!isDownloadDifferenceFiles)
				return (plusFileContent, null);

			if (isDownloadDifferenceFiles)
				return (plusFileContent, minusFileContent);

			return (null, null);
		}

		private static async Task<string?> ReadZipStream(ZipInputStream zipInputStream)
		{
			using (var entryMemoryStream = new MemoryStream())
			{
				zipInputStream.CopyTo(entryMemoryStream);

				entryMemoryStream.Position = 0; // Reset the position to the beginning of the stream

				using (var streamReader = new StreamReader(entryMemoryStream))
				{
					return await streamReader.ReadToEndAsync();
				}
			}
		}
	}
}
