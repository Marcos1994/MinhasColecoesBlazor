using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.ViewModels
{
	public class ColecaoGenealogiaVM
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public bool Publica { get; set; }
		public int IdDono { get; set; }
		public int? IdColecaoMaior { get; set; }
		public ColecaoGenealogiaVM ColecaoPai { get; set; }
	}
}
