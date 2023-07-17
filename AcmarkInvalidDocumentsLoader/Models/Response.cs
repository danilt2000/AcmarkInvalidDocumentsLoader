﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmarkInvalidDocumentsLoader.Models
{
	public class Response
	{
		public int StatusCode { get; set; }

		public string Message { get; set; }

		public Response(int statusCode, string message)
		{
			StatusCode = statusCode;
			Message = message;
		}
	}
}
