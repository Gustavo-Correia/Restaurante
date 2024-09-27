using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;
using Service;

namespace RestauranteWeb.Controllers
{
    public class ItemcardapioController : Controller
    {
        private readonly IItemcardapioService itemcardapioService;
        private readonly IMapper mapper;

        public int IdRestaurante { get; private set; }

        public ItemcardapioController(IItemcardapioService itemcardapioService, IMapper mapper)
        {
            this.itemcardapioService = itemcardapioService;
            this.mapper = mapper;
        }

        // GET: ItemcardapioController
        public ActionResult Index()
        {
            var listaItemcardapio = itemcardapioService.GetAll();
            var ItemscardapioViewModel = mapper.Map<List<ItemcardapioViewModel>>(listaItemcardapio);
            return View(ItemscardapioViewModel);
        }

        // GET: ItemcardapioController/Details/5
        public ActionResult Details(uint id)
        {
            var itemcardapio = itemcardapioService.Get(id);
            var ItemscardapioViewModel = mapper.Map<ItemcardapioViewModel>(itemcardapio);
            return View(ItemscardapioViewModel);
        }

        // GET: ItemcardapioController/Create
        public ActionResult Create()
        {
            var Itemcardapioview = new ItemcardapioViewModel
            {
                IdRestaurante = 1
            };
            return View(Itemcardapioview);
        }

        // POST: ItemcardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemcardapioViewModel itemcardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                var itemcardapio = mapper.Map<Itemcardapio>(itemcardapioViewModel);
                itemcardapioService.Create(itemcardapio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemcardapioController/Edit/5
        public ActionResult Edit(uint id)
        {
            var itemcardapio = itemcardapioService.Get(id);
            var itemcardapioViewModel = mapper.Map<ItemcardapioViewModel>(itemcardapio);
            return View(itemcardapioViewModel);
        }

        // POST: ItemcardapioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, ItemcardapioViewModel itemcardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                var itemcardapio = mapper.Map<Itemcardapio>(itemcardapioViewModel);
                itemcardapioService.Edit(itemcardapio);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemcardapioController/Delete/5
        public ActionResult Delete(uint id)
        {
            var itemcardapio = itemcardapioService.Get(id);
            var itemcardapioViewModel = mapper.Map<ItemcardapioViewModel>(itemcardapio);
            return View(itemcardapioViewModel);
        }

        // POST: ItemcardapioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ItemcardapioViewModel itemcardapioViewModel)
        {
            itemcardapioService.Delete(itemcardapioViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
