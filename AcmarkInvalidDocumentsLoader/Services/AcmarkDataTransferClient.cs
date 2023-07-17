using AcmarkInvalidDocumentsLoader.Interfaces;
using AcmarkInvalidDocumentsLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class AcmarkDataTransferClient : IUploadService, IRemoverService
	{
		public ApiWrapper ApiWrapper { get; set; }

		public AcmarkDataTransferClient(string mvcInvalidDocumentsWebLink)
		{
			ApiWrapper = new ApiWrapper(mvcInvalidDocumentsWebLink);
		}
		public Task<Response> UploadContentAsync(string documentNumber, string batch, string documentType, DateTime invalidationdate)
		{
			var responce = ApiWrapper.AddInvalidDocumentAsync(documentNumber, batch, documentType, invalidationdate);

			return null;
		}

		public Task<Response> RemoveContentAsync(string documentNumber)
		{





			throw new NotImplementedException();
		}

	}
}
