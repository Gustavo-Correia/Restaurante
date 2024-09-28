namespace RestauranteWeb.Models
{
    using System.ComponentModel.DataAnnotations;


    public class RestauranteViewModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O CNPJ do restaurante deve ser preenchido obrigatoriamente")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter exatamente 14 caracteres")]
        public string Cnpj { get; set; } = null!;

        [Required(ErrorMessage = "O nome do restaurante deve ser preenchido obrigatoriamente")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo nome do restaurante deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; } = null!;

        [StringLength(8, ErrorMessage = "O CEP deve ter no máximo 8 caracteres")]
        public string? Cep { get; set; }

        [StringLength(30, ErrorMessage = "A rua deve ter no máximo 30 caracteres")]
        public string? Rua { get; set; }

        [StringLength(30, ErrorMessage = "O bairro deve ter no máximo 30 caracteres")]
        public string? Bairro { get; set; }

        [StringLength(30, ErrorMessage = "A cidade deve ter no máximo 30 caracteres")]
        public string? Cidade { get; set; }

        [StringLength(2, ErrorMessage = "O estado deve ter exatamente 2 caracteres")]
        public string? Estado { get; set; }

        [StringLength(15, ErrorMessage = "Número de telefone inválido")]
        [Phone(ErrorMessage = "Número de telefone inválido")]
        public string? Telefone1 { get; set; }

        [StringLength(15, ErrorMessage = "Número de telefone inválido")]
        [Phone(ErrorMessage = "Número de telefone inválido")]
        public string? Telefone2 { get; set; }
    }


}
