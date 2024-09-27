using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class ItemcardapioViewModel
    {
        [Required(ErrorMessage = "ID do item do Cardapio é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome do item deve ter entre 5 e 45 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Preço do produto é obrigatório")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(500, ErrorMessage = "Detalhes deve ter no máximo 500 caracteres")]
        public string? Detalhes { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 1, ErrorMessage = "O item tem que estar ativo (1) ou inativo (0)")]
        public sbyte Ativo { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [RegularExpression("^(Sim|Não)$", ErrorMessage = "O item tem que estar 'Sim' (disponível) ou 'Não' (não disponível)")]
        public string Disponivel { get; set; } = null!;

        [Required(ErrorMessage = "ID do Restaurante é obrigatório")]
        public uint IdRestaurante { get; set; }
    }
}
