using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasColecoes.Client.Util
{
	public static class Formatar
	{
		public static string PrimeiroCaractereMaiusculo(string texto)
		{
			if (texto.Length == 0)
				return "";

			string[] palavras = texto.Split(' ');
			List<string> palavrasFormatadas = new List<string>();
			foreach (string p in palavras)
			{
				if (p.Length == 0)
					continue;
				else if (p.Length == 1)
					palavrasFormatadas.Add(char.ToUpper(p[0]).ToString());
				else
					palavrasFormatadas.Add(char.ToUpper(p[0]) + p.Substring(1));
			}
			return string.Join(' ', palavrasFormatadas);
		}
	}
}
