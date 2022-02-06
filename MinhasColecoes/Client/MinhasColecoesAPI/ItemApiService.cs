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
	public class ItemApiService
	{
		private readonly HttpService httpService;

		public ItemApiService(HttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task<ItemVM> Create(ItemIM input)
		{
			HttpClient client = await httpService.GetClient();
			HttpResponseMessage response = await client.PostAsJsonAsync($"Itens?idColecao={input.IdColecao}", input);

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return await response.Content.ReadFromJsonAsync<ItemVM>();
		}

		public async Task Delete(int idItem)
		{
			HttpClient client = await httpService.GetClient();
			HttpResponseMessage response = await client.DeleteAsync($"Itens/{idItem}");

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);
		}

		public async Task AtualizarRelacionamento(ItemBasicVM input)
		{
			HttpClient client = await httpService.GetClient();
			HttpResponseMessage response = await client.PutAsJsonAsync($"Itens/{input.Id}/Relacao?relacao={(int)input.Relacao}", input.Relacao);

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);
		}

		public async Task<List<ItemBasicVM>> GetByNome(int idColecao, string nome = "")
		{
			HttpClient client = await httpService.GetClient();

			string parametro = (nome.Length > 0) ? $"?nome={nome}" : "";
			HttpResponseMessage response = await client.GetAsync($"/Itens/{idColecao}/PorNome{parametro}");

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return await response.Content.ReadFromJsonAsync<List<ItemBasicVM>>();
		}
	}
}
