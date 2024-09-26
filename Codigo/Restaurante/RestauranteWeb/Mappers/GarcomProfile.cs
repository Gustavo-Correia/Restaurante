
using Core;
using AutoMapper;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
    public class GarcomProfile : Profile
    {
        public GarcomProfile()
        {
            CreateMap<GarcomViewModel, Garcom>().ReverseMap();
        }
    }
}
