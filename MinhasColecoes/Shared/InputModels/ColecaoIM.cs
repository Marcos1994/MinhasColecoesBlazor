using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels
{
	public class ColecaoIM
	{
		public int? IdColecaoMaior { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Descricao { get; set; } = string.Empty;
		public string Foto { get; set; } = string.Empty;
		public bool Publica { get; set; }
	}
}
