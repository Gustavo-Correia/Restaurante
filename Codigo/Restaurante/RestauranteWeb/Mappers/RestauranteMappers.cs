using AutoMapper;
using Core;

namespace RestauranteWeb.Mappers
{
    public class RestauranteProfile : Profile
    {
        public RestauranteProfile()
        {
            CreateMap<RestauranteProfile, Restaurante>().ReverseMap();
        }
    }
}
