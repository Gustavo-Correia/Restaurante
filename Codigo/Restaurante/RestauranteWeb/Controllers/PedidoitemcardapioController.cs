using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;
using Service;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RestauranteWeb.Controllers
{
    public class PedidoitemcardapioController : Controller
    {
        private readonly IPedidoitemcardapioService pedidoitemcardapio;
        private readonly IItemcardapioService itemCardapioService;
        private readonly IMapper mapper;

        public PedidoitemcardapioController(IPedidoitemcardapioService pedidoitemcardapio, IMapper mapper, IItemcardapioService itemCardapioService)
        {
            this.pedidoitemcardapio = pedidoitemcardapio;
            this.itemCardapioService = itemCardapioService;
            this.mapper = mapper;
        }
        // GET: Pedidoitemcardapio
        public ActionResult Index()
        {
            var listaPedidoitemcardapio = pedidoitemcardapio.GetAll();
            var PedidoitemcardapioViewModel = mapper.Map<List<PedidoitemcardapioViewModel>>(listaPedidoitemcardapio);
            return View(PedidoitemcardapioViewModel);
        }
        // GET: Pedidoitemcardapio/Create
        public ActionResult Create()
        {
            var Pedidoitemcardapioview = new PedidoitemcardapioViewModel
            {
                IdItemCardapio = 1,
                ItensCardapio = GetItensCardapioSelectList()
            };
            return View(Pedidoitemcardapioview);
        }
        // POST: Pedidoitemcardapio/Create
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

        // GET: Pedidoitemcardapio/Edit/5
        public ActionResult Edit(uint IdItemCardapio, uint IdPedido)
        {
            var Pedidoitemcardapio = pedidoitemcardapio.Get(IdItemCardapio, IdPedido);
            var PedidoItemcardapioViewModel = mapper.Map<PedidoitemcardapioViewModel>(Pedidoitemcardapio);
            PedidoItemcardapioViewModel.ItensCardapio = GetItensCardapioSelectList();
            return View(PedidoItemcardapioViewModel);
        }

        private IEnumerable<SelectListItem> GetItensCardapioSelectList()
        {
            var itens = itemCardapioService.GetAll();  
            return itens.Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = item.Nome 
            }).ToList();
        }
        // POST: Pedidoitemcardapio/Edit/5
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
        // GET: Pedidoitemcardapio/Details/5
        public ActionResult Details(uint IdItemCardapio, uint IdPedido)
        {
            
            var pedidoitemcardapio1 = pedidoitemcardapio.Get(IdItemCardapio, IdPedido);

            if (pedidoitemcardapio1 == null)
            {
                return NotFound();
            }

            
            var pedidoitemcardapioViewModel = new PedidoitemcardapioViewModel
            {
                IdItemCardapio = pedidoitemcardapio1.IdItemCardapio,
                IdPedido = pedidoitemcardapio1.IdPedido,
                Quantidade = pedidoitemcardapio1.Quantidade
            };

            return View(pedidoitemcardapioViewModel);
        }


        // GET: Pedidoitemcardapio/Delete/5
        public ActionResult Delete(uint IdItemCardapio, uint IdPedido)
        {
            var Pedidoitemcardapio = pedidoitemcardapio.Get(IdItemCardapio, IdPedido);
            var pedidoitemcardapioViewModel = mapper.Map<PedidoitemcardapioViewModel>(Pedidoitemcardapio);
            return View(pedidoitemcardapioViewModel);
        }

        // POST: Pedidoitemcardapio/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint IdItemCardapio, uint IdPedido, PedidoitemcardapioViewModel pedidoitemcardapio2)
        {
            pedidoitemcardapio.Delete(pedidoitemcardapio2.IdPedido, pedidoitemcardapio2.IdItemCardapio);
            return RedirectToAction(nameof(Index));
        }
    }
}