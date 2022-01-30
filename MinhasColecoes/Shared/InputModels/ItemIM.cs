using MinhasColecoes.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels
{
	public class ItemIM
	{
		public int IdColecao { get; set; }
		public string Nome { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public EnumRelacaoUsuarioItem Relacao { get; set; }
		public string Comentario { get; set; }
		public string Foto { get; set; }
	}
}
