using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public  interface IRestauranteService
    {
        uint Create(Restaurante restaurante);
        void Edit(Restaurante restaurante);
        void Delete(uint id);
        public int QuantidadeRestaurantesCadastrado();
        Restaurante? Get(uint id);
        IEnumerable<Restaurante> GetAll();
        IEnumerable<RestauranteDto> GetByNome(string nome);
        IEnumerable<RestauranteDto> GetDtos();
        string GerarRelatorioEstatisticas();
    }
}
