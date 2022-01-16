using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.ViewModels
{
	public class UsuarioVM
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string Foto { get; set; }
		public List<ColecaoBasicVM> ColecoesMembro { get; set; }
		public int QuantidadeMembro { get; set; }
		public int QuantidadeDono { get; set; }
		public int QuantidadeParticular { get; set; }
	}
}
