using MinhasColecoes.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.ViewModels
{
	public class ItemBasicVM
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public bool Original { get; set; }
		public int? IdOriginal { get; set; }
		public ItemBasicVM ItemOriginal { get; set; }
		public EnumRelacaoUsuarioItem Relacao { get; set; }
		public string Comentario { get; set; }
		public string Foto { get; set; }

		public string CodigoNome
		{
			get
			{
				return ((string.IsNullOrEmpty(Codigo)) ? "" : Codigo + ": " ) + Nome;
			}
		}
	}
}
