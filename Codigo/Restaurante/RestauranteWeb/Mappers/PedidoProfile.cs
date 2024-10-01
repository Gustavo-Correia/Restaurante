
using Core;
using AutoMapper;
using RestauranteWeb.Models;

namespace RestauranteWeb.Mappers
{
	public class PedidoProfile : Profile
	{
		public PedidoProfile()
		{
			CreateMap<PedidoViewModel, Pedido>().ReverseMap();
		}
	}
}
