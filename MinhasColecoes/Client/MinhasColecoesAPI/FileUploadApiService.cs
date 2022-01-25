using MinhasColecoes.Shared.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.MinhasColecoesAPI
{
	public class FileUploadApiService
	{
		private readonly HttpService httpService;

		public FileUploadApiService(HttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task<string> Upload(MultipartFormDataContent input, EnumCategoriasFotos categoria)
		{
			HttpClient client = await httpService.GetClient();
			HttpResponseMessage response = await client.PostAsync($"/FileUpload/{categoria.ToString()}", input);

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return httpService.BaseUrl + (await response.Content.ReadAsStringAsync());
		}
	}
}
