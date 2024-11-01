using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IPedidoService
	{
		uint Create(Pedido pedido);
		void Edit(Pedido pedido);
		void Delete(uint id);
        void AtualizarStatus(uint id, string novoStatus);
        Pedido? Get(uint id);
		IEnumerable<Pedido> GetAll();
		IEnumerable<ItemcardapioDto> GetById(uint Id);
        
    }
}
