using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
	public class MesaDto
	{
		public int Id { get; set; }
        public string Identificacao { get; set; } = null!;
		public string NomeRestaurante { get; set; } = null!;
		public string Status { get; set; } = null!;
    }
}
