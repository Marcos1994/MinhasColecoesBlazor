using Blazored.LocalStorage;
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
	public class UsuarioAPI
	{
		private readonly HttpService httpService;

		public UsuarioAPI(HttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task<HttpResponseMessage> Login(UsuarioLoginIM input)
		{
			HttpClient client = await httpService.GetClient();
			return await client.PostAsJsonAsync($"/Usuario/Login", input);
		}

		public async Task SetToken(UsuarioLoginVM usuario)
		{
			await httpService.SetToken(usuario);
		}

		public async Task Logout()
		{
			await httpService.ClearToken();
		}

		public async Task<bool> CheckAuthentication()
		{
			return await httpService.CheckAuthentication();
		}

		public async Task<HttpResponseMessage> GetUsuario(int? Id)
		{
			HttpClient client = await httpService.GetClient();

			if (Id == null)
				Id = await httpService.GetUserId();

			if (Id == null)
				return null;

			return await client.GetAsync($"Usuario/{Id}");
		}
	}
}
