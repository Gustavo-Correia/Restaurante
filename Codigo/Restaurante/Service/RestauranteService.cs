using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RestauranteService : IRestauranteService
    {
        private readonly RestauranteContext context;

        /// <summary>
        /// Implementa os serviços para manter os dados de Restaurante
        /// </summary>
        /// <param name="context"></param>
        public RestauranteService(RestauranteContext context)
        {
            this.context = context;
        }

        public uint Create(Restaurante restaurante)
        {
            context.Add(restaurante);
            context.SaveChanges();
            return restaurante.Id;
        }

        public void Delete(int id)
        {
            var restaurante = context.Restaurantes.Find(id);
            if (restaurante != null)
            {
                context.Remove(restaurante);
                context.SaveChanges();
            }
        }

        public void Edit(Restaurante restaurante)
        {
            
                context.Update(restaurante);
                context.SaveChanges();
           
        }

        public Restaurante? Get(int id)
        {
            return context.Restaurantes.Find(id);
        }

        public IEnumerable<Restaurante> GetAll()
        {
            return context.Restaurantes.ToList();
        }

        public IEnumerable<RestauranteDto> GetByNome(string nome)
        {
            return context.Restaurantes
                .Where(restaurante => restaurante.Nome.Contains(nome) && restaurante.Id != 0) 
                .Select(restaurante => new RestauranteDto
                {
                    Id = restaurante.Id,
                    Nome = restaurante.Nome,
                    Cnpj = restaurante.Cnpj,
                }).ToList();
        }

    }

}
