using Core.DTO;

namespace Core.Service
{
    public interface IGarcomService
    {
        uint Create(Garcom garcom);
        void Edit(Garcom garcom);
        void Delete(uint id);
        Garcom? Get(uint id);
        public int  QuantidadeGarcomCadastrado();
        IEnumerable<Garcom> GetAll();
        IEnumerable<GarcomDto> GetByNome(string nome);
        Task<List<GarcomDto>> BuscarGarconsPorRestauranteId(uint id);
        Task<List<GarcomDto>> BuscarGarconsPorCidade(string cidade);
    }
}
