using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels
{
	public class UsuarioLoginIM
	{
		[Required]
		[EmailAddress]
		public string Login { get; set; }
		[Required(ErrorMessage = "Informe sua senha!")]
		public string Senha { get; set; }
	}
}
