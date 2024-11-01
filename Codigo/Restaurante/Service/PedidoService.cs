using Core.DTO;
using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Service
{
	public class PedidoService : IPedidoService
	{
		private readonly RestauranteContext context;

		public PedidoService(RestauranteContext context)
		{
			this.context = context;
		}

        public void AtualizarStatus(uint id, string novoStatus)
        {
            var pedido = context.Pedidos.Find(id);
            if (pedido != null)
            {
                
                pedido.Status = novoStatus;
                context.SaveChanges();
            }
        }



        public uint Create(Pedido pedido) 
		{
			context.Add(pedido);
			context.SaveChanges();
			return pedido.Id;
		}

		public void Delete(uint id)
		{
			var pedido = context.Pedidos.Find(id); 

			if (pedido != null)
			{
				context.Remove(pedido);
				context.SaveChanges();
			}
		}

		public void Edit(Pedido pedido) 
		{
			context.Update(pedido);
			context.SaveChanges();
		}

		public Pedido? Get(uint id) 
		{
			return context.Pedidos.Find(id); 
		}

		public IEnumerable<Pedido> GetAll() 
		{
			return context.Pedidos.AsNoTracking(); 
		}

		public IEnumerable<ItemcardapioDto> GetById(uint id)
		{
			var query = from pedido in context.Pedidos
						where pedido.Id == id 
						select new ItemcardapioDto
						{
							Id = pedido.Id,
						};

			return query.AsNoTracking();
		}
        

    }
}
