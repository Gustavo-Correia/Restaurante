using Core.DTO;
using Core;
using System.Collections.Generic;
using System.Linq;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class PedidoitemcardapioService : IPedidoitemcardapioService
	{
		private readonly RestauranteContext context;

		public PedidoitemcardapioService(RestauranteContext context)
		{
			this.context = context;
		}
		public uint Create(Core.Pedidoitemcardapio pedidoitemcardapio)
		{
			context.Add(pedidoitemcardapio);
			context.SaveChanges();
			return pedidoitemcardapio.IdItemCardapio;
		}
		public void Edit(Core.Pedidoitemcardapio pedidoitemcardapio)
		{
			context.Update(pedidoitemcardapio);
			context.SaveChanges();
		}
        public void Delete(uint IdItemCardapio, uint IdPedido)
        {
            var pedidoitemcardapio = context.Pedidoitemcardapios.Find(IdItemCardapio, IdPedido);

            if (pedidoitemcardapio != null)
            {
                context.Remove(pedidoitemcardapio);
                context.SaveChanges();
            }
        }

        Core.Pedidoitemcardapio? IPedidoitemcardapioService.Get(uint IdItemCardapio, uint IdPedido)
        {
            return context.Pedidoitemcardapios.Find(IdItemCardapio, IdPedido);
        }

        public IEnumerable<Core.Pedidoitemcardapio> GetAll()
		{
			return context.Pedidoitemcardapios.AsNoTracking().ToList();
		}

		public IEnumerable<ItemcardapioDto> GetById(uint IdItemCardapio)
		{
			var query = from item in context.Pedidoitemcardapios
						where item.IdItemCardapio == IdItemCardapio
						select new ItemcardapioDto
						{
							Id = item.IdItemCardapio
							
						};

			return query.AsNoTracking().ToList();
		}

	}
}
