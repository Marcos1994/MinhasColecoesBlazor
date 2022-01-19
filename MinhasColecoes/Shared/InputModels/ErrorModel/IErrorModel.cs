using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.InputModels.ErrorModel
{
	public interface IErrorModel
	{
		List<ValidatorEM> GetErrors();
	}
}
