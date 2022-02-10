using MinhasColecoes.Client.MinhasColecoesAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace MinhasColecoes.Client.Models
{
	public class ImageUploaderModel
	{
		public long MaxFileSize { get; private set; }
		public IFileReference File { get; private set; }
		public string BaseUrl { get; private set; }
		public string Url { get; private set; }
		public string Preview { get; private set; }
		public string Nome { get; private set; }
		public string Tipo { get; private set; }
		public long Tamanho { get; private set; }

		public string NomeSemExtensao
		{ get { return Path.GetFileNameWithoutExtension(Nome); } }

		public ImageUploaderModel(EnumCategoriasFotos Categoria, string baseUrl)
		{
			BaseUrl = baseUrl;
			MaxFileSize = 1024;
			switch (Categoria)
			{
				case EnumCategoriasFotos.Colecao:
					MaxFileSize *= 100;
					break;
				case EnumCategoriasFotos.Perfil:
					MaxFileSize *= 150;
					break;
				case EnumCategoriasFotos.Item:
					MaxFileSize *= 300;
					break;
			}
		}

		public async Task SetFileAsync(IFileReference fileReference)
		{
			if (fileReference == null)
				throw new Exception("Arquivo não encontrado.");

			Clear();

			var fileInfo = await fileReference.ReadFileInfoAsync();
			if (fileInfo.Size > MaxFileSize)
				throw new Exception($"O arquivo deve ter no máximo {MaxFileSize / 1024}Mb.");

			File = fileReference;
			Nome = fileInfo.Name;
			Tipo = fileInfo.Type;
			Tamanho = fileInfo.Size;

			ShowFile(await File.CreateMemoryStreamAsync((int)Tamanho));
		}

		private void ShowFile(MemoryStream fileStream)
		{
			Span<byte> span = new Span<byte>(fileStream.GetBuffer()).Slice(0, (int)fileStream.Length);
			Preview = $"data:image/jpg;base64,{Convert.ToBase64String(span)}";
			fileStream.Dispose();
			fileStream.Close();
		}

		public void SetUrl(string url)
		{
			Clear();
			Url = url;
			Preview = BaseUrl + url;
		}

		public void Clear()
		{
			File = null;
			Url = Nome = Tipo = Preview = string.Empty;
			Tamanho = 0;
		}
	}
}
