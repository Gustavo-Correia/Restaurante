using Core.DTO;
using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class AtendimentoService : IAtendimentoService
	{
		private readonly RestauranteContext context;

		public AtendimentoService(RestauranteContext context)
		{
			this.context = context;
		}

		public uint Create(Atendimento atendimento) 
		{
			context.Add(atendimento);
			context.SaveChanges();
			return atendimento.Id;
		}

		public void Delete(uint id)
		{
			var atendimento = context.Atendimentos.Find(id); 

			if (atendimento != null)
			{
				context.Remove(atendimento);
				context.SaveChanges();
			}
		}

		public void Edit(Atendimento atendimento) 
		{
			context.Update(atendimento);
			context.SaveChanges();
		}

		public Atendimento? Get(uint id) 
		{
			return context.Atendimentos.Find(id); 
		}

		public IEnumerable<Atendimento> GetAll() 
		{
			return context.Atendimentos.AsNoTracking(); 
		}

		public IEnumerable<AtendimentoDto> GetById(uint id)
		{
			var query = from atendimento in context.Atendimentos
						where atendimento.Id == id 
						select new AtendimentoDto
						{
							Id = atendimento.Id,
						};

			return query.AsNoTracking();
		}

	}
}
