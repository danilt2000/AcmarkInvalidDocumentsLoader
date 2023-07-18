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

		public static readonly string OpDifference = ConfigurationManager.AppSettings["OpDifference"];

		public static readonly string OpsVseFileLink = ConfigurationManager.AppSettings["OpsVseFileLink"];

		public static readonly string OpsDifference = ConfigurationManager.AppSettings["OpsDifference"];

		public static readonly string CdVseFileLink = ConfigurationManager.AppSettings["CdVseFileLink"];

		public static readonly string CdDifference = ConfigurationManager.AppSettings["CdDifference"];

		public static readonly string DevAcmarkEuApiLink = ConfigurationManager.AppSettings["DevAcmarkEuApiLink"];
	}
}
