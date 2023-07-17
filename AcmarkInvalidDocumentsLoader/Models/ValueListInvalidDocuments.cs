using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Models
{
	public class ValueListInvalidDocuments
	{
		[JsonPropertyName("@odata.etag")]
		public string OdataEtag { get; set; }
		public string acm_documentnumber { get; set; }
		public string _owningbusinessunit_value { get; set; }
		public int statecode { get; set; }
		public int statuscode { get; set; }
		public string _createdby_value { get; set; }
		public int timezoneruleversionnumber { get; set; }
		public int acm_documenttype { get; set; }
		public string _ownerid_value { get; set; }
		public string acm_batch { get; set; }
		public DateTime modifiedon { get; set; }
		public string _owninguser_value { get; set; }
		public string _modifiedby_value { get; set; }
		public int versionnumber { get; set; }
		public string acm_listinvaliddocumentid { get; set; }
		public DateTime createdon { get; set; }
		public DateTime acm_invalidationdate { get; set; }
		public object _modifiedonbehalfby_value { get; set; }
		public object importsequencenumber { get; set; }
		public object _createdonbehalfby_value { get; set; }
		public object utcconversiontimezonecode { get; set; }
		public object overriddencreatedon { get; set; }
		public object _owningteam_value { get; set; }
	}
}
