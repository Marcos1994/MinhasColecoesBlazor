using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.MinhasColecoesAPI
{
	public class ColecaoAPI
	{
		private readonly HttpService httpService;

		public ColecaoAPI(HttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task<HttpResponseMessage> GetById(int Id)
		{
			HttpClient client = await httpService.GetClient();
			return await client.GetAsync($"Colecoes/{Id}");
		}

		public async Task<HttpResponseMessage> GetByName(string nome, int? idColecaoPrincipal = null)
		{
			HttpClient client = await httpService.GetClient();

			string parametro = (nome.Length > 0) ? $"?nome={nome}" : "";
			return (idColecaoPrincipal == null)
				? await client.GetAsync($"Colecoes{parametro}")
				: await client.GetAsync($"/Colecoes/{idColecaoPrincipal}/Subcolecoes{parametro}");
		}

		public async Task<HttpResponseMessage> GetByUser(string nome, int? idUsuario)
		{
			HttpClient client = await httpService.GetClient();

			if (idUsuario == null)
				idUsuario = (await httpService.GetUser()).Id;

			string parametro = (nome.Length > 0) ? $"?nome={nome}" : "";
			return await client.GetAsync($"Usuario/{idUsuario}/MinhasColecoes{parametro}");
		}
	}
}
