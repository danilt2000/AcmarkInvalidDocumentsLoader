using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Interfaces
{
	public interface IDownloadService
	{
		Task<string> DownloadFileContentAsync(string fileUrl);
	}
}
