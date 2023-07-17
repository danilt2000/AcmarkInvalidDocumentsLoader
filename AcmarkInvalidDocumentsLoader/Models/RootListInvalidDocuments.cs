using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Models
{
	public class RootListInvalidDocuments
	{
		[JsonPropertyName("@odata.context")]
		public string OdataContext { get; set; }
		public List<ValueListInvalidDocuments> value { get; set; }
	}
}
