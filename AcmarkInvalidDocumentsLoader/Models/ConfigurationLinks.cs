using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Models
{
	public class ConfigurationLinks
	{
		public static readonly string MvcInvalidDocumentsWebLink = ConfigurationManager.AppSettings["MvcInvalidDocumentsWebLink"];

		public static readonly string OpVseFileLink = ConfigurationManager.AppSettings["OpVseFileLink"];

		public static readonly string DevAcmarkEuApiLink = ConfigurationManager.AppSettings["DevAcmarkEuApiLink"];
	}
}
