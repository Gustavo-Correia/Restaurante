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
			var mesa = context.Mesas.Find(atendimento.IdMesa);
			mesa.Status = "OCUPADA";
			context.SaveChanges();
			return atendimento.Id;
		}

		public void Delete(uint id)
		{
			var atendimento = context.Atendimentos.Find(id); 

			if (atendimento != null)
			{
				context.Remove(atendimento);
				var mesa = context.Mesas.Find(atendimento.IdMesa);
				mesa.Status = "LIVRE";
				context.SaveChanges();
			}
		}

		public void Edit(Atendimento atendimento) 
		{
			context.Update(atendimento);
			if(atendimento.Status == "C" || atendimento.Status == "F")
			{
				var mesa = context.Mesas.Find(atendimento.IdMesa);
				mesa.Status = "LIVRE";
			}
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

        public IEnumerable<AtendimentoDto> GetByStatus(string status)
        {
			var query = context.Atendimentos
				.Where(x => x.Status == status)
				.Select(x => new AtendimentoDto
				{
					Id = x.Id,
					DataHoraInicio = x.DataHoraInicio,
					DataHoraFim = x.DataHoraFim,
					IdMesa = x.IdMesa,
					NomeRestaurante = x.IdMesaNavigation.IdRestauranteNavigation.Nome,
					Status = x.Status,
					Total = x.Total,
					TotalConta = x.TotalConta,
					TotalDesconto = x.TotalConta,
					TotalServico = x.TotalServico
				});
			return query.AsNoTracking();
        }
    }
}
