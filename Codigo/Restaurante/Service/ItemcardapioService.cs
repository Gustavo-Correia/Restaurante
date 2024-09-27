using Core.DTO;
using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ItemcardapioService : IItemcardapioService
    {
        private readonly RestauranteContext context;
        public ItemcardapioService(RestauranteContext context)
        {
            this.context = context;
        }

        public uint Create(Itemcardapio itemcardapio)
        {
            context.Add(itemcardapio);
            context.SaveChanges();
            return itemcardapio.Id;
        }

        public void Delete(uint id)
        {
            var itemcardapio = context.Garcoms.Find(id);

            if (itemcardapio != null)
            {
                context.Remove(itemcardapio);
                context.SaveChanges();
            }

        }

        public void Edit(Itemcardapio itemcardapio)
        {
            var existenciacardapio = context.Itemcardapios.Find(itemcardapio.Id);
            if (existenciacardapio == null)
            {
                throw new Exception("Garcom nao encontrado");
            }

            context.Update(existenciacardapio);

        }

        public Itemcardapio? Get(uint id)
        {
            return context.Itemcardapios.Find(id);
        }

        public IEnumerable<Itemcardapio> GetAll()
        {
            return context.Itemcardapios.AsNoTracking();
        }

        public IEnumerable<ItemcardapioDto> GetByNome(string nome)
        {
            var query = from Itemcardapio in context.Itemcardapios
                        where Itemcardapio.Nome.StartsWith(nome)
                        orderby Itemcardapio.Nome
                        select new ItemcardapioDto
                        {
                            Id = Itemcardapio.Id,
                            Nome = Itemcardapio.Nome,
                            Ativo = Itemcardapio.Ativo,
                            Disponivel = Itemcardapio.Disponivel,
                        };
            return query;
        }
    }
}
