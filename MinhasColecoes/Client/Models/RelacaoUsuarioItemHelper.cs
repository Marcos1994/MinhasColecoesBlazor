using MinhasColecoes.Shared.Enums;

namespace MinhasColecoes.Client.Models
{
	public static class RelacaoUsuarioItemHelper
	{
		public static string Nome(EnumRelacaoUsuarioItem Relacao)
		{
			switch (Relacao)
			{
				case EnumRelacaoUsuarioItem.Desejo:
					return "Desejo";
				case EnumRelacaoUsuarioItem.AguardandoRecebimento:
					return "Aguardando Recebimento";
				case EnumRelacaoUsuarioItem.Possuo:
					return "Possuo";
				case EnumRelacaoUsuarioItem.Trocar:
					return "Possuo para troca";
				case EnumRelacaoUsuarioItem.Vender:
					return "Possuo para vender";
				case EnumRelacaoUsuarioItem.JaPossui:
					return "Ja tive";
				default:
					return "Não possuo";
			}
		}

		public static string Icone(EnumRelacaoUsuarioItem Relacao)
		{
			switch (Relacao)
			{
				case EnumRelacaoUsuarioItem.Desejo:
					return "bi-heart";
				case EnumRelacaoUsuarioItem.AguardandoRecebimento:
					return "bi-heart-half";
				case EnumRelacaoUsuarioItem.Possuo:
					return "bi-heart-fill";
				case EnumRelacaoUsuarioItem.Trocar:
					return "bi-arrow-left-right";
				case EnumRelacaoUsuarioItem.Vender:
					return "bi-currency-dollar";
				case EnumRelacaoUsuarioItem.JaPossui:
					return "bi-hourglass";
				default:
					return "bi-x-circle";
			}
		}
	}
}
