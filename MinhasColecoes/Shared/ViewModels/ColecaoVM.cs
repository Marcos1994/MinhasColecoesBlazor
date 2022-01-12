using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.ViewModels
{
	public class ColecaoVM
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string Foto { get; set; }
		public bool Publica { get; set; }
		public bool UsuarioParticipa { get; set; }

		public int IdDono { get; set; }
		public UsuarioBasicVM Dono { get; set; }

		public int? IdColecaoMaior { get; set; }
		public ColecaoGenealogiaVM ColecaoMaior { get; set; }

		public List<UsuarioBasicVM> UsuariosColecao { get; set; }
		public int QuantidadeMembros { get { return (UsuariosColecao == null) ? 0 : UsuariosColecao.Count(); } }

		public List<ColecaoBasicVM> Colecoes { get; set; } = new List<ColecaoBasicVM>();
		public int QuantidadeSubcolecoes { get { return (Colecoes == null) ? 0 : Colecoes.Count(); } }

		public List<ItemBasicVM> Itens { get; set; } = new List<ItemBasicVM>();
		public int QuantidadeItens { get { return (Itens == null) ? 0 : Itens.Count(); } }
	}
}
