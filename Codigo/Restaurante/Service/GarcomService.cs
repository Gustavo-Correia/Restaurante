
using Core.DTO;
using Microsoft.EntityFrameworkCore;


namespace Core.Service
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
            var garcon = context.Garcoms.Find(id);

            if(garcon != null)
            {
                context.Remove(garcon);
                context.SaveChanges();
            }
         
        }

        public void Edit(Garcom garcom)
        {
            var existenciaGarcom = context.Garcoms.Find(garcom.Id);
            if(existenciaGarcom == null)
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
    }
}
