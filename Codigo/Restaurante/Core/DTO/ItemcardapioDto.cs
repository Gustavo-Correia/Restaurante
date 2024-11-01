using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ItemcardapioDto
    {
        public uint Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }

        public string Disponivel { get; set; } = null!;

        public uint IdRestaurante { get; set; }
    }
}
