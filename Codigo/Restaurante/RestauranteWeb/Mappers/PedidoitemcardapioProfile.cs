
using Core;
using AutoMapper;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
	public class PedidoitemcardapioProfile : Profile
	{
		public PedidoitemcardapioProfile()
		{
			CreateMap<PedidoitemcardapioViewModel, Pedidoitemcardapio>().ReverseMap();
		}
	}
}
