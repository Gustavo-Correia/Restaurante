
using Core;
using AutoMapper;
using RestauranteWeb.Models;
using Core.DTO;

namespace RestauranteWeb.Mappers
{
	public class AtendimentoProfile : Profile
	{
		public AtendimentoProfile()
		{
			CreateMap<AtendimentoViewModel, Atendimento>().ReverseMap();
			CreateMap<AtendimentoViewModel, AtendimentoDto>().ReverseMap();
		}
	}
}
