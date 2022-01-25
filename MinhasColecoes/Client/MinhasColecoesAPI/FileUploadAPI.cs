using MinhasColecoes.Shared.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.MinhasColecoesAPI
{
	public class FileUploadAPI
	{
		private readonly HttpService httpService;

		public FileUploadAPI(HttpService httpService)
		{
			this.httpService = httpService;
		}

		public string GetBaseUrl()
		{
			return httpService.BaseUrl;
		}

		public async Task<HttpResponseMessage> Upload(MultipartFormDataContent input)
		{
			HttpClient client = await httpService.GetClient();
			return await client.PostAsync($"/FileUpload", input);
		}
	}
}
