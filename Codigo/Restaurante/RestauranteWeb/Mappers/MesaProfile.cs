
using Core;
using AutoMapper;
using RestauranteWeb.Models;
using Core.DTO;

namespace RestauranteWeb.Mappers
{
	public class MesaProfile : Profile
	{
		public MesaProfile()
		{
			CreateMap<MesaViewModel, Mesa>().ReverseMap();
            CreateMap<MesaViewModel, MesaDto>().ReverseMap();
        }
	}
}
