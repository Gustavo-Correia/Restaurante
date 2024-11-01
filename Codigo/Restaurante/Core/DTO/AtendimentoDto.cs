using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
	public class AtendimentoDto
	{
        public uint Id { get; set; }

        public DateTime DataHoraInicio { get; set; } = DateTime.Now;

        public DateTime? DataHoraFim { get; set; }

        public decimal TotalConta { get; set; }

        public decimal TotalServico { get; set; }

        public decimal TotalDesconto { get; set; }

        public string NomeRestaurante { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public int IdMesa { get; set; }
    }
}
