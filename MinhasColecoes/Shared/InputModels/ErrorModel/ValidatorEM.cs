using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels.ErrorModel
{
	public class ValidatorEM
	{
		public string Propriedade { get; private set; }
		public string[] Mensagens { get; private set; }

		public ValidatorEM(string propriedade, string[] mensagens)
		{
			Propriedade = propriedade;
			Mensagens = mensagens;
		}

	}
}
