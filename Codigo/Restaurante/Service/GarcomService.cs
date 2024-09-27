
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;


namespace Service
{
    public class GarcomService : IGarcomService
    {
        private readonly RestauranteContext context;
        public GarcomService(RestauranteContext context)
        {
            this.context = context;
        }

        public uint Create(Garcom garcom)
        {
            context.Add(garcom);
            context.SaveChanges();
            return garcom.Id;
        }



        public void Delete(uint id)
        {
            var garcom = context.Garcoms.Find(id);

            if (garcom != null)
            {
                context.Remove(garcom);
                context.SaveChanges();
            }

        }

        public void Edit(Garcom garcom)
        {
            var existenciaGarcom = context.Garcoms.Find(garcom.Id);
            if (existenciaGarcom == null)
            {
                throw new Exception("Garcom nao encontrado");
            }

            context.Update(existenciaGarcom);

        }

        public Garcom? Get(uint id)
        {
            return context.Garcoms.Find(id);
        }

        public IEnumerable<Garcom> GetAll()
        {
            return context.Garcoms.AsNoTracking();
        }

        public IEnumerable<GarcomDto> GetByNome(string nome)
        {
            var query = from garcom in context.Garcoms
                        where garcom.Nome.StartsWith(nome)
                        orderby garcom.Nome
                        select new GarcomDto
                        {
                            Id = garcom.Id,
                            Nome = garcom.Nome
                        };
            return query;
        }

        Garcom? IGarcomService.Get(uint id)
        {
            return context.Garcoms.Find(id);
        }

        IEnumerable<Garcom> IGarcomService.GetAll()
        {
            return context.Garcoms.AsNoTracking().ToList();
        }
    }
}
