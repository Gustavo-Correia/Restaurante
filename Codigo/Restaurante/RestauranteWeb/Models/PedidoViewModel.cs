using System.ComponentModel.DataAnnotations;


namespace RestauranteWeb.Models
{
	public class PedidoViewModel
	{
		[Key]
		[Required(ErrorMessage = "O ID do pedido é obrigatório.")]
		public uint Id { get; set; }

		[Required(ErrorMessage = "A data e hora da solicitação são obrigatórias.")]
		public DateTime DataHoraSolicitacao { get; set; }

		[Required(ErrorMessage = "A data e hora do atendimento são obrigatórias.")]
		public DateTime DataHoraAtendimento { get; set; }

		[Required(ErrorMessage = "O ID do atendimento é obrigatório.")]
		public uint IdAtendimento { get; set; }

		[Required(ErrorMessage = "O ID do garçom é obrigatório.")]
		public uint IdGarcom { get; set; }

		/// <summary>
		/// Status do pedido:
		/// S - Solicitado
		/// C - Cancelado
		/// A - Atendido
		/// </summary>
		[Required(ErrorMessage = "O status do pedido é obrigatório.")]
		[StringLength(1, ErrorMessage = "O status deve ter um único caractere: 'S', 'C' ou 'A'.")]
		public string Status { get; set; } = null!;

        [Required(ErrorMessage = "O novo status do pedido é obrigatório.")]
        [RegularExpression("^[SCA]$", ErrorMessage = "O novo status deve ser 'S', 'C' ou 'A'.")]
        public string novostatus { get; set; } = null!;

        /// <summary>
        /// Detalhes adicionais do pedido (opcional).
        /// </summary>
        public string? PedidoDetalhes { get; set; }
	}
}