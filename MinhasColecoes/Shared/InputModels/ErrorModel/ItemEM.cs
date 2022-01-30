using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels.ErrorModel
{
	public class ItemEM : IErrorModel
	{
		public string[] IdColecao { get; set; }
		public string[] Nome { get; set; }
		public string[] Codigo { get; set; }
		public string[] Descricao { get; set; }
		public List<ValidatorEM> GetErrors()
		{
			List<ValidatorEM> errors = new List<ValidatorEM>();

			if (IdColecao != null && IdColecao.Length > 0)
				errors.Add(new ValidatorEM("IdColecao", IdColecao));

			if (Codigo != null && Codigo.Length > 0)
				errors.Add(new ValidatorEM("Codigo", Codigo));

			if (Nome != null && Nome.Length > 0)
				errors.Add(new ValidatorEM("Nome", Nome));

			if (Descricao != null && Descricao.Length > 0)
				errors.Add(new ValidatorEM("Descricao", Descricao));

			return errors;
		}
	}
}
