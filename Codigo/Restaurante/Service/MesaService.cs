using Core.DTO;
using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class MesaService : IMesaService
	{
		private readonly RestauranteContext context;

		public MesaService(RestauranteContext context)
		{
			this.context = context;
		}

		public uint Create(Mesa mesa) 
		{
			context.Add(mesa);
			context.SaveChanges();
			return (uint)mesa.Id;
		}

		public void Delete(int id)
		{
			var mesa = context.Mesas.Find(id); 

			if (mesa != null)
			{
				context.Remove(mesa);
				context.SaveChanges();
			}
		}

		public void Edit(Mesa mesa) 
		{
			context.Update(mesa);
			context.SaveChanges();
		}

		public Mesa? Get(uint id) 
		{
			return context.Mesas.Find(id); 
		}

		public IEnumerable<Mesa> GetAll() 
		{
			return context.Mesas.AsNoTracking(); 
		}

		public IEnumerable<MesaDto> GetById(uint id)
		{
			var query = from mesa in context.Mesas
						where mesa.Id == id 
						select new MesaDto
						{
							Id = (uint)mesa.Id,
						};

			return query.AsNoTracking();
		}

	}
}
