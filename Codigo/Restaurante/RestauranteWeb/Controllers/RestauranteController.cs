using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class RestauranteController : Controller
    {
        private readonly IRestauranteService restauranteService;
        private readonly IMapper mapper;

        public RestauranteController(IRestauranteService restauranteService, IMapper mapper)
        {
            this.restauranteService = restauranteService;
            this.mapper = mapper;
        }


        // GET: RestauranteController

        public ActionResult Index()
        {
            var listaRestaurante = restauranteService.GetAll();
            var listaRestauranteModel = mapper.Map<List<RestauranteViewModel>>(listaRestaurante);
            return View(listaRestauranteModel);
        }

        // GET: RestauranteController/Details/5
        public ActionResult Details(int id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // GET: RestauranteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestauranteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestauranteViewModel restauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurante = mapper.Map<Restaurante>(restauranteViewModel);
                restauranteService.Create(restaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RestauranteController/Edit/5
        public ActionResult Edit(int id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestauranteViewModel restauranteViewModel)
        {
            if (ModelState.IsValid)
            {
                var restaurante = mapper.Map<Restaurante>(restauranteViewModel);
                restauranteService.Edit(restaurante);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: RestauranteController/Delete/5
        public ActionResult Delete(int id)
        {
            var restaurante = restauranteService.Get(id);
            RestauranteViewModel restauranteViewModel = mapper.Map<RestauranteViewModel>(restaurante);
            return View(restauranteViewModel);
        }

        // POST: RestauranteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RestauranteViewModel restauranteViewModel)
        {
            restauranteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
