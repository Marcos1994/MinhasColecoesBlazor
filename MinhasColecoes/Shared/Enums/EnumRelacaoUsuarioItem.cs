using System.ComponentModel.DataAnnotations;

namespace MinhasColecoes.Shared.Enums
{
	public enum EnumRelacaoUsuarioItem
	{
		[Display(Name ="Não possuo")]
		NaoPossuo = 0,

		[Display(Name = "Desejo")]
		Desejo = 1,

		[Display(Name = "Aguardando")]
		AguardandoRecebimento = 2,

		[Display(Name = "Possuo")]
		Possuo = 3,

		[Display(Name = "Vendo")]
		Vender = 4,

		[Display(Name = "Tenho Para Troca")]
		Trocar = 5,

		[Display(Name = "Já possuí")]
		JaPossui = 6
	}
}
