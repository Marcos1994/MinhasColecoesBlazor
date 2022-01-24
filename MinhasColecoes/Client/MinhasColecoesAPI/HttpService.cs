using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MinhasColecoes.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.MinhasColecoesAPI
{
    public class HttpService
    {
		private UsuarioLoginVM usuarioAtual;
		public event Action OnChange;
		private void NotifyStateChange() => OnChange?.Invoke();

        private readonly HttpClient client;
        private readonly NavigationManager navigationManager;
        private readonly ILocalStorageService localStorage;

		public HttpService(HttpClient client, NavigationManager navigationManager, ILocalStorageService localStorage)
		{
			this.client = client;
			this.navigationManager = navigationManager;
			this.localStorage = localStorage;
		}

		public async Task<HttpClient> GetClient()
		{
			if (await CheckAuthentication())
			{
				string token = (await GetUser()).Token;
				HttpResponseMessage response = await client.GetAsync($"Usuario/VerificarToken?token={token}");

				if (!response.IsSuccessStatusCode)
				{
					await ClearToken();
					navigationManager.NavigateTo("sessaoexpirada");
				}
				else if (client.DefaultRequestHeaders.Authorization == null)
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}

			return client;
		}

		public async Task<UsuarioLoginVM> GetUser()
		{
			usuarioAtual = await localStorage.GetItemAsync<UsuarioLoginVM>("Usuario");
			return usuarioAtual;
		}

		public UsuarioLoginVM GetUserSync()
		{
			return usuarioAtual;
		}

		public async Task<bool> CheckAuthentication()
		{
			return await localStorage.ContainKeyAsync("Usuario");
		}

		public async Task SetToken(UsuarioLoginVM usuario)
		{
			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Bearer", usuario.Token);
			await localStorage.SetItemAsync<UsuarioLoginVM>("Usuario", usuario);
			usuarioAtual = usuario;
			NotifyStateChange();
		}

		public async Task ClearToken()
		{
			client.DefaultRequestHeaders.Authorization = null;
			await localStorage.ClearAsync();
			usuarioAtual = null;
			NotifyStateChange();
		}
	}
}
