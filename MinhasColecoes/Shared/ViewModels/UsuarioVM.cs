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
		public List<ColecaoBasicVM> ColecoesMembro { get; set; } = new List<ColecaoBasicVM>();
		public int QuantidadeMembro { get; set; }
		public int QuantidadeDono { get; set; }
		public int QuantidadeParticular { get; set; }

		public void SetColecoesMembro(List<ColecaoBasicVM> colecoesMembro)
		{
			ColecoesMembro = colecoesMembro;
			QuantidadeDono = colecoesMembro.Where(c => c.IdDono == Id).Count();
			QuantidadeMembro = colecoesMembro.Count() - QuantidadeDono;
			QuantidadeParticular = colecoesMembro.Where(c => !c.Publica).Count();
		}
	}
}
