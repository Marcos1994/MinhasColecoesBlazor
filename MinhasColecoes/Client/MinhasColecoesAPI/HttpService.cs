using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
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
			if (await localStorage.ContainKeyAsync("Token"))
			{
				string token = await localStorage.GetItemAsync<string>("Token");
				HttpResponseMessage response = await client.GetAsync($"Usuario/VerificarToken?token={token}");

				if (!response.IsSuccessStatusCode)
				{
					await ClearToken();
					navigationManager.NavigateTo("sessaoexpirada", true);
				}

				if (client.DefaultRequestHeaders.Authorization == null)
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}

			return client;
		}

		public async Task SetToken(string token)
		{
			client.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Bearer", token);
			await localStorage.SetItemAsync<string>("Token", token);
		}

		public async Task ClearToken()
		{
			client.DefaultRequestHeaders.Authorization = null;
			await localStorage.ClearAsync();
		}

		public async Task<bool> CheckAuthentication()
		{
			return await localStorage.ContainKeyAsync("Token");
		}
	}
}
