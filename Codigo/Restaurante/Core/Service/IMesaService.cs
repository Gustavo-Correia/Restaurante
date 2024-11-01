using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IMesaService
    {
        uint Create(Mesa mesa);
        void Edit(Mesa mesa);
        void Delete(int id);
        Mesa? Get(int id);
        IEnumerable<Mesa> GetAll();
        IEnumerable<MesaDto> GetById(int Id);
        IEnumerable<MesaDto> GetDtos();
        IEnumerable<MesaDto> GetMesasLivres();
    }
}
