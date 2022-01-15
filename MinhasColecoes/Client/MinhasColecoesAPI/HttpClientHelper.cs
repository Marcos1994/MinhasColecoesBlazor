using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.MinhasColecoesAPI
{
	public class HttpClientHelper
	{
		private readonly ILocalStorageService localStorage;
		private readonly HttpClient client;

		public HttpClientHelper(ILocalStorageService localStorage, HttpClient client)
		{
			this.localStorage = localStorage;
			this.client = client;
		}

		public async Task<HttpClient> GetClient()
		{
			if (client.DefaultRequestHeaders.Authorization == null && await localStorage.ContainKeyAsync("Token"))
				client.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", await localStorage.GetItemAsync<string>("Token"));
			return client;
		}

		public async Task SetToken(string token)
		{
			await localStorage.SetItemAsync<string>("Token", token);
		}

		public async Task ClearToken()
		{
			await localStorage.ClearAsync();
		}

		public async Task<bool> CheckAuthentication()
		{
			return client.DefaultRequestHeaders.Authorization != null || await localStorage.ContainKeyAsync("Token");
		}
	}
}
