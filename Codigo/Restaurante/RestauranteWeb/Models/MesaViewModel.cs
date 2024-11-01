using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Permissions;


namespace RestauranteWeb.Models
{
    public class MesaViewModel
    {
        [Key]
        [Required(ErrorMessage = "O ID da mesa é obrigatório.")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A identificação da mesa é obrigatória.")]
        [Display(Name = "Identificação")]
        public string Identificacao { get; set; } = null!;
        [Display(Name = "Restaurante")]
        public string? NomeRestaurante { get; set; } = null!;

        [Display(Name = "Status")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ID do restaurante é obrigatório.")]
        public uint IdRestaurante { get; set; }
        public SelectList? Restaurantes { get; set; } = null;
        public SelectList? SelectStatus { get; set; } = null;

    }
}
