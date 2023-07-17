using AcmarkInvalidDocumentsLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Interfaces
{
	internal interface IRemoverService
	{
		Task<Response> RemoveContentAsync(string documentId);
	}
}
