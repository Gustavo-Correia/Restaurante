using System.ComponentModel.DataAnnotations;


namespace RestauranteWeb.Models
{
    public class AtendimentoViewModel
    {
        [Key]
        [Required(ErrorMessage = "O ID do atendimento é obrigatório.")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "A identificação é obrigatória.")]
        public string Identificacao { get; set; } = null!;

        [Required(ErrorMessage = "O ID do restaurante é obrigatório.")]
        public uint IdRestaurante { get; set; }

        [Required(ErrorMessage = "O nome do restaurante é obrigatório.")]
        public string NomeRestaurante { get; set; } = null!;

        /// <summary>
        /// Status do atendimento:
        /// S - Solicitado
        /// C - Cancelado
        /// A - Atendido
        /// </summary>
        [Required(ErrorMessage = "O status do atendimento é obrigatório.")]
        [StringLength(1, ErrorMessage = "O status deve ter um único caractere: 'S', 'C' ou 'A'.")]
        public string Status { get; set; } = null!;

     
    }
}
