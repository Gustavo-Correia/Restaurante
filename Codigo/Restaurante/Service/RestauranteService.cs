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
        /// <param name="context">Contexto do banco de dados para interagir com a entidade Restaurante</param>
        public RestauranteService(RestauranteContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria um novo Restaurante no banco de dados.
        /// </summary>
        /// <param name="restaurante">Entidade Restaurante que será criada</param>
        /// <returns>Id do restaurante criado</returns>
        public uint Create(Restaurante restaurante)
        {
            context.Add(restaurante);
            context.SaveChanges();
            return restaurante.Id;
        }

        /// <summary>
        /// Remove um Restaurante existente com base no seu Id.
        /// </summary>
        /// <param name="id">Id do Restaurante a ser removido</param>
        public void Delete(int id)
        {
            var restaurante = context.Restaurantes.Find(id);
            if (restaurante != null)
            {
                context.Remove(restaurante);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza as informações de um Restaurante existente.
        /// </summary>
        /// <param name="restaurante">Entidade Restaurante com os dados atualizados</param>
        public void Edit(Restaurante restaurante)
        {
            context.Update(restaurante);
            context.SaveChanges();
        }

        /// <summary>
        /// Obtém um Restaurante específico pelo seu Id.
        /// </summary>
        /// <param name="id">Id do Restaurante</param>
        /// <returns>Entidade Restaurante correspondente ao Id, ou null se não encontrado</returns>
        public Restaurante? Get(int id)
        {
            return context.Restaurantes.Find(id);
        }

        /// <summary>
        /// Retorna todos os Restaurantes cadastrados.
        /// </summary>
        /// <returns>Lista de todas as entidades Restaurante</returns>
        public IEnumerable<Restaurante> GetAll()
        {
            return context.Restaurantes.ToList();
        }

        /// <summary>
        /// Busca Restaurantes com base no nome.
        /// </summary>
        /// <param name="nome">Nome do Restaurante ou parte dele para realizar a busca</param>
        /// <returns>Lista de DTOs de Restaurante correspondentes à busca por nome</returns>
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
