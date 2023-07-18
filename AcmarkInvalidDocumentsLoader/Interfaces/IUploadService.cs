using AcmarkInvalidDocumentsLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Interfaces
{
	public interface IUploadService
	{
		Task UploadContentAsync(string documentNumber, string batch, string documentType, DateTime? invalidationdate);
	}
}
