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
	public class UsuarioApiService
	{
		private readonly HttpService httpService;

		public UsuarioApiService(HttpService httpService)
		{
			this.httpService = httpService;
		}

		public async Task<UsuarioLoginVM> Login(UsuarioLoginIM input)
		{
			HttpClient client = await httpService.GetClient();
			HttpResponseMessage response = await client.PostAsJsonAsync($"/Usuario/Login", input);

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			UsuarioLoginVM usuario = await response.Content.ReadFromJsonAsync<UsuarioLoginVM>();
			await httpService.SetToken(usuario);
			return usuario;
		}

		public async Task Logout()
		{
			await httpService.ClearToken();
		}

		public async Task<bool> CheckAuthentication()
		{
			return await httpService.CheckAuthentication();
		}

		public async Task<UsuarioVM> GetUsuario(int? Id)
		{
			HttpClient client = await httpService.GetClient();

			if (Id == null)
			{
				if (await httpService.CheckAuthentication())
					Id = (await httpService.GetUser()).Id;
				else
					return null;
			}

			HttpResponseMessage response = await client.GetAsync($"Usuario/{Id}");

			if (!response.IsSuccessStatusCode)
				throw new HttpResponseException(response);

			return await response.Content.ReadFromJsonAsync<UsuarioVM>();
		}
	}
}
