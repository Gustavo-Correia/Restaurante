using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace RestauranteWeb.Models
{
    public class AtendimentoViewModel
    {
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Horário de abertura")]
        public DateTime DataHoraInicio { get; set; } = DateTime.Now;

        [Display(Name = "Horário de fechamento")]
        public DateTime? DataHoraFim { get; set; }

        [Display(Name = "Conta")]
        public decimal TotalConta { get; set; }

        [Display(Name = "Serviço")]
        public decimal TotalServico { get; set; }

        [Display(Name = "Desconto")]
        public decimal TotalDesconto { get; set; }

        [Display(Name = "Restaurante")]
        public string NomeRestaurante { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public string Status { get; set; } = string.Empty;

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Mesa")]
        public int IdMesa { get; set; }

        public SelectList ? SelectMesa { get; set; }
    }
}
