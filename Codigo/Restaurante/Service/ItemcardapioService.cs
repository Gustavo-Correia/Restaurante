using Core.DTO;
using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace Service
{
    public class ItemcardapioService : IItemcardapioService
    {
        private readonly RestauranteContext context;
        private readonly HttpClient _httpClient;
        private const string EdamamApiUrl = "https://api.edamam.com/search";
        public ItemcardapioService(RestauranteContext context)
        {
            this.context = context;
            _httpClient = new HttpClient();
        }

        public uint Create(Itemcardapio itemcardapio)
        {
            context.Add(itemcardapio);
            context.SaveChanges();
            return itemcardapio.Id;
        }

        public void Delete(uint id)
        {
            var itemcardapio = context.Itemcardapios.Find(id);

            if (itemcardapio != null)
            {
                context.Remove(itemcardapio);
                context.SaveChanges();
            }

        }

        public void Edit(Itemcardapio itemcardapio)
        {

            context.Update(itemcardapio);
            context.SaveChanges();

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
                        };
            return query;
        }

        public async Task<List<ItemcardapioDto>> Buscaritemporid(uint id)
        {
            var itemcardapio = await context.Itemcardapios
                .Where(g => g.Id == id)
                .Select(g => new ItemcardapioDto
                {
                    Id = g.Id,
                    Nome = g.Nome,
                    Preco = g.Preco,
                    Disponivel = g.Disponivel,
                    IdRestaurante = g.IdRestaurante

                })
                .ToListAsync();

            return itemcardapio;
        }

        public async Task<List<ItemcardapioDto>> BuscarItensPorNome(string nome)
        {
            return await context.Itemcardapios
                .Where(i => i.Nome.Contains(nome))
                .Select(i => new ItemcardapioDto
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    Preco = i.Preco,
                    Disponivel = i.Disponivel,
                    IdRestaurante = i.IdRestaurante
                })
                .ToListAsync();
        }
        
        public async Task<string> ObterReceita(string nomeReceita)
        {
            string appId = "eff0c826";
            string appKey = "4617d32bd4bff87df0a7403dca61b4ac";
            string endpoint = "https://api.edamam.com/search";
            string query = HttpUtility.UrlEncode(nomeReceita);
            string url = $"{endpoint}?q={query}&app_id={appId}&app_key={appKey}&lang=pt";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                 
                    
                    return result;
                }
                else
                {
                    return "Erro ao buscar receita.";
                }

            }
        }

        
        }
    }
    
