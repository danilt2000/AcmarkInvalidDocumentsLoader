using AcmarkInvalidDocumentsLoader.Interfaces;
using AcmarkInvalidDocumentsLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AcmarkInvalidDocumentsLoader.Services
{
	public class AcmarkDataTransferClient : IUploadService, IRemoverService
	{
		public AcmarkApiWrapper ApiWrapper { get; set; }

		public AcmarkDataTransferClient(string mvcInvalidDocumentsWebLink)
		{
			ApiWrapper = new AcmarkApiWrapper(mvcInvalidDocumentsWebLink);
		}
		public async Task<Response> UploadContentAsync(string documentNumber, string batch, string documentType, DateTime invalidationdate)
		{
			await ApiWrapper.AddDocumentAsync(documentNumber, batch, documentType, invalidationdate);

			//SOME CONTOLLING DATE AND LOGING IF NULL

			return null;
		}

		public Dictionary<string, ValueListInvalidDocuments> GetAllDocuments()
		{
			var entities = ApiWrapper.GetAllDocuments();

			//SOME CONTOLLING DATE AND LOGING IF NULL

			return entities;
		}
		public async Task<Response> RemoveContentAsync(string documentId)
		{

			await ApiWrapper.RemoveDocumentAsync(documentId);

			//SOME CONTOLLING DATE AND LOGING IF NULL

			return null;
		}

	}
}
