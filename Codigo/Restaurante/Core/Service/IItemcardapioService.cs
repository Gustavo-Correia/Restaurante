using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IItemcardapioService
    {
        uint Create(Itemcardapio itemcardapio);
        void Edit(Itemcardapio itemcardapio);
        void Delete(uint id);
        Itemcardapio? Get(uint id);
        IEnumerable<Itemcardapio> GetAll();
        IEnumerable<ItemcardapioDto> GetByNome(string nome);

        Task<List<ItemcardapioDto>> Buscaritemporid(uint id);
        Task<List<ItemcardapioDto>> BuscarItensPorNome(string nome);

        Task<string> ObterReceita(string nomeReceita);
    }
}
