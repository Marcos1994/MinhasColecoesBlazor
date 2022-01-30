using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasColecoes.Shared.ErrorModels
{
	public class ValidationErrorModel
	{
		public string Title { get; set; }
		public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
	}
}
