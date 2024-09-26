using System.ComponentModel.DataAnnotations;

namespace RestauranteWeb.Models
{
    public class GarcomViewModel
    {
        [Required(ErrorMessage = "Código do Garçom é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome do garçom deve ter entre 5 e 45 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres")]
        public string Cpf { get; set; } = null!;

        [StringLength(8, ErrorMessage = "CEP deve ter no máximo 8 caracteres")]
        public string? Cep { get; set; }

        [StringLength(45, ErrorMessage = "Rua deve ter no máximo 45 caracteres")]
        public string? Rua { get; set; }

        [StringLength(45, ErrorMessage = "Bairro deve ter no máximo 45 caracteres")]
        public string? Bairro { get; set; }

        [StringLength(45, ErrorMessage = "Cidade deve ter no máximo 45 caracteres")]
        public string? Cidade { get; set; }

        [StringLength(2, ErrorMessage = "Estado deve ter exatamente 2 caracteres")]
        public string? Estado { get; set; }

        [StringLength(11, ErrorMessage = "Telefone 1 deve ter no máximo 11 caracteres")]
        public string? Telefone1 { get; set; }

        [StringLength(11, ErrorMessage = "Telefone 2 deve ter no máximo 11 caracteres")]
        public string? Telefone2 { get; set; }
        
        [Required(ErrorMessage = "ID do Restaurante é obrigatório")]
        public uint IdRestaurante { get; set; }
    }
}
