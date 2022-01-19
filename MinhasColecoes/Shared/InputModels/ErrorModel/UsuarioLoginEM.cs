using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels.ErrorModel
{
	public class UsuarioLoginEM : IErrorModel
	{
		public string[] Login { get; set; }
		public string[] Senha { get; set; }

		public List<ValidatorEM> GetErrors()
		{
			List<ValidatorEM> errors = new List<ValidatorEM>();

			if (Login != null && Login.Length > 0)
				errors.Add(new ValidatorEM("Login", Login));

			if (Senha != null && Senha.Length > 0)
				errors.Add(new ValidatorEM("Senha", Senha));

			return errors;
		}
	}
}
