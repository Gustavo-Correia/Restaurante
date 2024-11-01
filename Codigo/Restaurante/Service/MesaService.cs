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

        public Mesa? Get(int id)
        {
            return context.Mesas.Find(id);
        }

        public IEnumerable<Mesa> GetAll()
        {
            return context.Mesas.Include(x => x.IdRestauranteNavigation).AsNoTracking();
        }

        public IEnumerable<string> GetAllStatus()
        {
            return context.Mesas.DistinctBy(x => x.Status).Select(x => x.Status);
        }

        public IEnumerable<MesaDto> GetById(int id)
        {
            var query = from mesa in context.Mesas
                        where mesa.Id == id
                        select new MesaDto
                        {
                            Id = mesa.Id,
                            Identificacao = mesa.Identificacao,
                            NomeRestaurante = mesa.IdRestauranteNavigation.Nome,
                            Status = mesa.Status,
                        };

            return query.AsNoTracking();
        }

        public IEnumerable<MesaDto> GetDtos()
        {
            var query = from mesa in context.Mesas
                        select new MesaDto
                        {
                            Id = mesa.Id,
                            Identificacao = mesa.Identificacao,
                            NomeRestaurante = mesa.IdRestauranteNavigation.Nome,
                            Status = mesa.Status,
                        };
            return query.AsNoTracking();
        }

        public IEnumerable<MesaDto> GetMesasLivres()
        {
            var query = from mesa in context.Mesas
                        where mesa.Status == "LIVRE"
                        select new MesaDto
                        {
                            Id = mesa.Id,
                            Identificacao = mesa.Identificacao,
                            NomeRestaurante = mesa.IdRestauranteNavigation.Nome,
                            Status = mesa.Status,
                        };
            return query.AsNoTracking();
        }
    }
}
