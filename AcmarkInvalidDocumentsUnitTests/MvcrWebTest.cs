using AcmarkInvalidDocumentsLoader.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AcmarkInvalidDocumentsUnitTests
{
	[TestClass]
	public class MvcrWebTest
	{
		[TestMethod]
		public async Task TestMvcrSiteAvailability()
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					var response = await client.GetAsync("https://aplikace.mvcr.cz/neplatne-doklady/");

					Assert.IsTrue(response.IsSuccessStatusCode, $"The website https://aplikace.mvcr.cz/neplatne-doklady/ is not available");
				}
				catch (Exception ex)
				{
					Assert.Fail($"An exception occurred while checking website availability: {ex.Message}");
				}
			}
		}


		[TestMethod]
		public async Task TestFileDownload()
		{
			try
			{
				MvcrDownloader mvcrDownloadService = new MvcrDownloader("https://aplikace.mvcr.cz/neplatne-doklady/");

				var responce = await mvcrDownloadService.DownloadFileContentAsync("ViewFile.aspx?typ_dokladu=0&amp;rozdil=1");

				Assert.IsTrue(!string.IsNullOrWhiteSpace(responce) && !string.IsNullOrWhiteSpace(responce), "Downloading not available");
			}

			catch (Exception ex)
			{
				Assert.Fail($"An exception occurred while checking website downloading availability: {ex.Message}");
			}
		}
	}
}
