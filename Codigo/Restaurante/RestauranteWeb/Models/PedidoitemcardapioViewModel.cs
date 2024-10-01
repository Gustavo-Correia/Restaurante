using RestauranteWeb.Controllers;
using System.ComponentModel.DataAnnotations;



namespace RestauranteWeb.Models
{
	public class PedidoitemcardapioViewModel
	{
		[Key]
		[Required(ErrorMessage = "O ID do item do cardápio é obrigatório.")]
		public uint IdItemCardapio { get; set; }

		[Required(ErrorMessage = "O ID do pedido é obrigatório.")]
		public uint IdPedido { get; set; }

		[Required(ErrorMessage = "A quantidade é obrigatória.")]
		[Range(1, (double)decimal.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
		public decimal Quantidade { get; set; }
	}
}