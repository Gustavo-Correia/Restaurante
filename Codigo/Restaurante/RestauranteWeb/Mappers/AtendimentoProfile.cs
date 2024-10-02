
using Core;
using AutoMapper;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
	public class AtendimentoProfile : Profile
	{
		public AtendimentoProfile()
		{
			CreateMap<AtendimentoViewModel, Atendimento>().ReverseMap();
		}
	}
}
