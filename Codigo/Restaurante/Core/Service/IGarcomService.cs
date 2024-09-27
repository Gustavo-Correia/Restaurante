using Core.DTO;

namespace Core.Service
{
    public interface IGarcomService
    {
        uint Create(Garcom garcom);
        void Edit(Garcom garcom);
        void Delete(uint id);
        Garcom? Get(uint id);
        IEnumerable<Garcom> GetAll();
        IEnumerable<GarcomDto> GetByNome(string nome);
    }
}
