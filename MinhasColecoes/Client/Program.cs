using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Tewr.Blazor.FileReader;
using MinhasColecoes.Client.MinhasColecoesAPI;

namespace MinhasColecoes.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddOptions();
			builder.Services.AddAuthorizationCore();

			//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44308") });
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
			//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddFileReaderService(o =>
			{
				o.UseWasmSharedBuffer = true;
			});

			builder.Services.AddScoped<HttpService>();
			builder.Services.AddScoped<FileUploadApiService>();
			builder.Services.AddScoped<UsuarioApiService>();
			builder.Services.AddScoped<ColecaoApiService>();
			builder.Services.AddScoped<ItemApiService>();

			await builder.Build().RunAsync();
		}
	}
}
