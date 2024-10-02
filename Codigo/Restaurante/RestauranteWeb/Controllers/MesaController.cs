using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class MesaController : Controller
    {
        private readonly IMesaService mesa;
        private readonly IMapper mapper;

        public MesaController(IMesaService mesa, IMapper mapper)
        {
            this.mesa = mesa;
            this.mapper = mapper;
        }
        // GET: MesaController
        public ActionResult Index()
        {
            var listaMesa = mesa.GetAll();
            var MesaViewModel = mapper.Map<List<MesaViewModel>>(listaMesa);
            return View(MesaViewModel);
        }
        // GET: MesaController/Create
        public ActionResult Create()
        {
            var Mesaview = new MesaViewModel
            {
                Id = 1
            };
            return View(Mesaview);
        }
        // POST: MesaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MesaViewModel mesaViewModel)
        {
            if (ModelState.IsValid)
            {
                var Mesa = mapper.Map<Mesa>(mesaViewModel);
                mesa.Create(Mesa);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MesaController/Edit/5
        public ActionResult Edit(uint id)
        {
            var Mesa = mesa.Get(id);
            var MesaViewModel = mapper.Map<MesaViewModel>(Mesa);
            return View(MesaViewModel);
        }

        // POST:MesaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, MesaViewModel mesaViewModel)
        {
            if (ModelState.IsValid)
            {
                var mesa1 = mapper.Map<Mesa>(mesaViewModel);
                mesa.Edit(mesa1);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MesaController/Delete/5
        public ActionResult Delete(uint id)
        {
            var Mesa = mesa.Get(id);
            var mesaViewModel = mapper.Map<MesaViewModel>(mesa);
            return View(mesaViewModel);
        }

        // POST: MesaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MesaViewModel mesa2)
        {
            mesa.Delete(mesa2.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}

