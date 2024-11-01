using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IPedidoitemcardapioService
	{
        uint Create(Pedidoitemcardapio pedidoitemcardapio);
        void Edit(Pedidoitemcardapio pedidoitemcardapio);
        void Delete(uint IdItemCardapio, uint IdPedido);
        Pedidoitemcardapio? Get(uint IdItemCardapio, uint IdPedido);
        IEnumerable<Pedidoitemcardapio> GetAll();
        IEnumerable<ItemcardapioDto> GetById(uint IdItemCardapio);

    }
}
