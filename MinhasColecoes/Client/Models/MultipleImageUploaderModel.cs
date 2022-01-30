using MinhasColecoes.Shared.Enums;
using MinhasColecoes.Shared.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.Models
{
	public class MultipleImageUploaderModel
	{
		public string Nome { get; set; }
		public ItemIM Item { get; private set; }
		public ImageUploaderModel ArquivoFoto { get; private set; }
		public List<string> Erros { get; private set; }

		public MultipleImageUploaderModel(int idColecao, ImageUploaderModel arquivoFoto)
		{
			Nome = System.IO.Path.GetFileNameWithoutExtension(arquivoFoto.Nome);
			ArquivoFoto = arquivoFoto;
			Item = new ItemIM()
			{
				IdColecao = idColecao,
				Nome = Nome,
				Relacao = EnumRelacaoUsuarioItem.NaoPossuo
			};
			Erros = new List<string>();
		}
	}
}
