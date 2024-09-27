using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IItemcardapioService
    {
        uint Create(Itemcardapio garcom);
        void Edit(Itemcardapio garcom);
        void Delete(uint id);
        Itemcardapio? Get(uint id);
        IEnumerable<Garcom> GetAll();
        IEnumerable<Itemcardapio> GetByNome(string nome);
    }
}
