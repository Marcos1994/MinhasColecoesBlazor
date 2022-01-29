using MinhasColecoes.Shared.InputModels;
using MinhasColecoes.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.MinhasColecoesAPI
{
	public class ColecaoApiService
	{
		private readonly HttpService httpService;

		public ColecaoApiService(HttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task<ColecaoVM> GetById(int Id)
		{
			HttpClient client = await httpService.GetClient();
			HttpResponseMessage response = await client.GetAsync($"Colecoes/{Id}");

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return await response.Content.ReadFromJsonAsync<ColecaoVM>();
		}

		public async Task<List<ColecaoBasicVM>> GetByName(string nome, int? idColecaoPrincipal = null)
		{
			HttpClient client = await httpService.GetClient();

			string parametro = (nome.Length > 0) ? $"?nome={nome}" : "";
			HttpResponseMessage response = (idColecaoPrincipal == null)
				? await client.GetAsync($"Colecoes{parametro}")
				: await client.GetAsync($"/Colecoes/{idColecaoPrincipal}/Subcolecoes{parametro}");

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return await response.Content.ReadFromJsonAsync<List<ColecaoBasicVM>>();
		}

		public async Task<List<ColecaoBasicVM>> GetByUser(string nome, int? idUsuario)
		{
			HttpClient client = await httpService.GetClient();

			if (idUsuario == null)
				idUsuario = (await httpService.GetUser()).Id;

			string parametro = (nome.Length > 0) ? $"?nome={nome}" : "";
			HttpResponseMessage response = await client.GetAsync($"Usuario/{idUsuario}/MinhasColecoes{parametro}");
			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return await response.Content.ReadFromJsonAsync<List<ColecaoBasicVM>>();
		}

		public async Task<ColecaoVM> Create(ColecaoIM input)
		{
			HttpClient client = await httpService.GetClient();
			HttpResponseMessage response = await client.PostAsJsonAsync($"Colecoes", input);

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return await response.Content.ReadFromJsonAsync<ColecaoVM>();
		}
	}
}
