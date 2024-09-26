using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class GarcomControler : Controller
    {
        private readonly IGarcomService garcomService;
        private readonly IMapper mapper;


        public GarcomControler(IGarcomService garcomService, IMapper mapper)
        {
            this.garcomService = garcomService;
            this.mapper = mapper;
        }


        // GET: GarcomControler
        public ActionResult Index()
        {
            var listaGarcom = garcomService.GetAll();
            var listaGarcomViewModel = mapper.Map<List<GarcomViewModel>>(listaGarcom);
            return View(listaGarcomViewModel);
        }

        // GET: GarcomControler/Details/5
        public ActionResult Details(uint id)
        {
            var garcom = garcomService.Get(id);
            var garcomViewModel = mapper.Map<GarcomViewModel>(garcom);
            return View(garcomViewModel);
        }

        // GET: GarcomControler/Create
        public ActionResult Create()
        {
            var GarcomViewModel = new GarcomViewModel
            {
                IdRestaurante = 1
            };
            return View(GarcomViewModel);
        }

        // POST: GarcomControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GarcomViewModel garcomViewModel)
        {
            if (ModelState.IsValid)
            {
                var garcom = mapper.Map<Garcom>(garcomViewModel);
                garcomService.Create(garcom);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: GarcomControler/Edit/5
        public ActionResult Edit(uint id)
        {
            var garcom = garcomService.Get(id);
            var garcomViewModel = mapper.Map<GarcomViewModel>(garcom);
            return View(garcomViewModel);
        }

        // POST: GarcomControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id,GarcomViewModel garcomViewModel)
        {
            if (ModelState.IsValid)
            {
                var garcom = mapper.Map<Garcom>(garcomViewModel);
                garcomService.Edit(garcom);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: GarcomControler/Delete/5
        public ActionResult Delete(uint id)
        {
            var garcom = garcomService.Get(id);
            var garcomViewModel = mapper.Map<GarcomViewModel>(garcom);
            return View(garcomViewModel);
        }

        // POST: GarcomControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(GarcomViewModel garcomViewModel)
        {
            garcomService.Delete(garcomViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
