using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;
using Service;

namespace RestauranteWeb.Controllers
{
	public class PedidoController : Controller
	{
		private readonly IPedidoService pedido;
		private readonly IMapper mapper;

		public PedidoController(IPedidoService pedido, IMapper mapper)
		{
			this.pedido = pedido;
			this.mapper = mapper;
		}
		// GET: ItemcardapioController
		public ActionResult Index()
		{
			var listaPedido = pedido.GetAll();
			var PedidoViewModel = mapper.Map<List<PedidoViewModel>>(listaPedido);
			return View(PedidoViewModel);
		}
		// GET: ItemcardapioController/Create
		public ActionResult Create()
		{
			var Pedidoview = new PedidoViewModel
			{
				IdAtendimento = 1
			};
			return View(Pedidoview);
		}
		// POST: ItemcardapioController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(PedidoViewModel pedidoViewModel)
		{
			if (ModelState.IsValid)
			{
				var Pedido = mapper.Map<Pedido>(pedidoViewModel);
				pedido.Create(Pedido);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ItemcardapioController/Edit/5
		public ActionResult Edit(uint id)
		{
			var Pedido = pedido.Get(id);
			var PedidoViewModel = mapper.Map<PedidoViewModel>(Pedido);
			return View(PedidoViewModel);
		}

		// POST: ItemcardapioController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(uint id, PedidoViewModel pedidoViewModel)
		{
			if (ModelState.IsValid)
			{
				var pedido1 = mapper.Map<Pedido>(pedidoViewModel);
				pedido.Edit(pedido1);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ItemcardapioController/Delete/5
		public ActionResult Delete(uint id)
		{
			var Pedido = pedido.Get(id);
			var pedidoViewModel = mapper.Map<PedidoViewModel>(Pedido);
			return View(pedidoViewModel);
		}

		// POST: ItemcardapioController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, PedidoViewModel pedido2)
		{
			pedido.Delete(pedido2.Id);
			return RedirectToAction(nameof(Index));
		}
	}
}
