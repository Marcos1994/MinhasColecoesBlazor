using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels.ErrorModel
{
	public class ColecaoEM : IErrorModel
	{
		public string[] IdColecaoMaior { get; set; }
		public string[] Nome { get; set; }
		public string[] Descricao { get; set; }
		public string[] Foto { get; set; }
		public string[] Publica { get; set; }

		public List<ValidatorEM> GetErrors()
		{
			List<ValidatorEM> errors = new List<ValidatorEM>();

			if (IdColecaoMaior != null && IdColecaoMaior.Length > 0)
				errors.Add(new ValidatorEM("IdColecaoMaior", IdColecaoMaior));

			if (Nome != null && Nome.Length > 0)
				errors.Add(new ValidatorEM("Nome", Nome));

			if (Descricao != null && Descricao.Length > 0)
				errors.Add(new ValidatorEM("Descricao", Descricao));

			if (Foto != null && Foto.Length > 0)
				errors.Add(new ValidatorEM("Foto", Foto));

			if (Publica != null && Publica.Length > 0)
				errors.Add(new ValidatorEM("Publica", Publica));

			return errors;
		}
	}
}
