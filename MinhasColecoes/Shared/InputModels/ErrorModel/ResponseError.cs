using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels.ErrorModel
{
	public class ResponseError<T>
	{
		public HttpStatusCode Status { get; set; }
		public T Errors { get; set; }
	}
}
