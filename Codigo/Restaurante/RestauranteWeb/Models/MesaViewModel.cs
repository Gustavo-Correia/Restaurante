using System.ComponentModel.DataAnnotations;


namespace RestauranteWeb.Models
{
    public class MesaViewModel
    {
        [Key]
        [Required(ErrorMessage = "O ID da mesa é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A identificação da mesa é obrigatória.")]
        public string Identificacao { get; set; } = null!;

        [Required(ErrorMessage = "O ID do restaurante é obrigatório.")]
        public uint IdRestaurante { get; set; }

        // Para exibir o nome do restaurante vinculado à mesa
        [Required(ErrorMessage = "O nome do restaurante é obrigatório.")]
        public string NomeRestaurante { get; set; } = null!;

        /// <summary>
        /// Status da mesa:
        /// L - Livre
        /// O - Ocupada
        /// R - Reservada
        /// </summary>
        [Required(ErrorMessage = "O status da mesa é obrigatório.")]
        [StringLength(1, ErrorMessage = "O status deve ter um único caractere: 'L', 'O' ou 'R'.")]
        public string Status { get; set; } = null!;

        
    }
}
