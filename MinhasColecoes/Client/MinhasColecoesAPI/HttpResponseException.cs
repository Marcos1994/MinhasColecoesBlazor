using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.MinhasColecoesAPI
{
	public class HttpResponseException : Exception
	{
		public HttpResponseMessage Response { get; private set; }
		public HttpResponseException(HttpResponseMessage response)
		{
			Response = response;
		}
	}
}
