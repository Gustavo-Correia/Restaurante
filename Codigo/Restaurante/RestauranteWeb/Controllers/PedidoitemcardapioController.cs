using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;


namespace RestauranteWeb.Controllers
{
	public class PedidoitemcardapioController : Controller
	{
		private readonly IPedidoitemcardapioService pedidoitemcardapio;
		private readonly IMapper mapper;

		public PedidoitemcardapioController(IPedidoitemcardapioService pedidoitemcardapio, IMapper mapper)
		{
			this.pedidoitemcardapio = pedidoitemcardapio;
			this.mapper = mapper;
		}
		// GET: ItemcardapioController
		public ActionResult Index()
		{
			var listaPedidoitemcardapio = pedidoitemcardapio.GetAll();
			var PedidoitemcardapioViewModel = mapper.Map<List<PedidoitemcardapioViewModel>>(listaPedidoitemcardapio);
			return View(PedidoitemcardapioViewModel);
		}
		// GET: ItemcardapioController/Create
		public ActionResult Create()
		{
			var Pedidoitemcardapioview = new PedidoitemcardapioViewModel
			{
				IdItemCardapio = 1
			};
			return View(Pedidoitemcardapioview);
		}
		// POST: ItemcardapioController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(PedidoitemcardapioViewModel pedidoitemcardapioViewModel)
		{
			if (ModelState.IsValid)
			{
				var Pedidoitemcardapio = mapper.Map<Pedidoitemcardapio>(pedidoitemcardapioViewModel);
				pedidoitemcardapio.Create(Pedidoitemcardapio);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ItemcardapioController/Edit/5
		public ActionResult Edit(uint id)
		{
			var Pedidoitemcardapio = pedidoitemcardapio.Get(id);
			var PedidoItemcardapioViewModel = mapper.Map<PedidoitemcardapioViewModel>(Pedidoitemcardapio);
			return View(PedidoItemcardapioViewModel);
		}

		// POST: ItemcardapioController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(uint id, PedidoitemcardapioViewModel pedidoitemcardapioViewModel)
		{
			if (ModelState.IsValid)
			{
				var pedidoitemcardapio1 = mapper.Map<Pedidoitemcardapio>(pedidoitemcardapioViewModel);
				pedidoitemcardapio.Edit(pedidoitemcardapio1);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ItemcardapioController/Delete/5
		public ActionResult Delete(uint id)
		{
			var Pedidoitemcardapio = pedidoitemcardapio.Get(id);
			var pedidoitemcardapioViewModel = mapper.Map<PedidoitemcardapioViewModel>(Pedidoitemcardapio);
			return View(pedidoitemcardapioViewModel);
		}

		// POST: ItemcardapioController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, PedidoitemcardapioViewModel pedidoitemcardapio2)
		{
			pedidoitemcardapio.Delete(pedidoitemcardapio2.IdPedido);
			return RedirectToAction(nameof(Index));
		}
	}
}
