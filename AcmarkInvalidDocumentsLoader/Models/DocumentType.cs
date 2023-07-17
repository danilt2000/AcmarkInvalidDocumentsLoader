using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AcmarkInvalidDocumentsLoader.Models
{
	public class DocumentType
	{
		public static readonly string OpWithoutSeries = ConfigurationManager.AppSettings["OpWithoutSeries"];

		public static readonly string OpWithSeries = ConfigurationManager.AppSettings["OpWithSeries"];

		public static readonly string PassportPurple = ConfigurationManager.AppSettings["PassportPurple"];

		public static readonly string PassportGreen = ConfigurationManager.AppSettings["PassportGreen"];
	}
}
