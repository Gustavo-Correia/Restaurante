
using Core;
using AutoMapper;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
	public class MesaProfile : Profile
	{
		public MesaProfile()
		{
			CreateMap<MesaViewModel, Mesa>().ReverseMap();
		}
	}
}
