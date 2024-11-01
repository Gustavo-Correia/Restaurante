using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RestauranteWeb.Models;
using Service;

namespace RestauranteWeb.Controllers
{
    public class GarcomController : Controller
    {
        private readonly IGarcomService garcomService;
        private readonly IMapper mapper;


        public GarcomController(IGarcomService garcomService, IMapper mapper)
        {
            this.garcomService = garcomService;
            this.mapper = mapper;
        }


        // GET: GarcomControler
        public ActionResult Index()
        {
            var listaGarcom = garcomService.GetAll();
            var listaGarcomViewModel = mapper.Map<List<GarcomViewModel>>(listaGarcom);
            int quantidadeGarcons = garcomService.QuantidadeGarcomCadastrado();
            ViewBag.Quantidade = quantidadeGarcons;
            return View(listaGarcomViewModel);
        }

        // GET: GarcomControler/Details/5
        public ActionResult Details(uint id)
        {
            Garcom? garcom = garcomService.Get(id);
            if(garcom == null)
            {
                return NotFound();
            }
            GarcomViewModel garcomModel = mapper.Map<GarcomViewModel>(garcom);
            return View(garcomModel);
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
                return RedirectToAction(nameof(Index)); 
             
            }
            return View(garcomViewModel);
        }
        

        // GET: GarcomControler/Edit/5
        public ActionResult Edit(uint id)
        {
            var garcom = garcomService.Get(id);
            if (garcom == null)
            {
                return NotFound(); // Retorna 404 se não encontrado
            }
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
                return RedirectToAction(nameof(Index));
            }
            return View(garcomViewModel);
        }


        // GET: GarcomControler/Delete/5
        public ActionResult Delete(uint id)
        {
            var garcom = garcomService.Get(id);
            if (garcom == null)
            {
                return NotFound(); // Retorna 404 se não encontrado
            }
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

        public async Task<ActionResult> BuscarGarconsPorRestauranteId(uint id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var garconsDto = await garcomService.BuscarGarconsPorRestauranteId(id);
            if (garconsDto == null || garconsDto.Count == 0)
            {
                return BadRequest("ID inválido.");
            }

            
            var garconsViewModel = garconsDto.Select(static g => new GarcomViewModel
            {
                Id = g.Id,
                Nome = g.Nome,
                Cpf = g.Cpf,
                Telefone1 = g.Telefone1,
                IdRestaurante = g.IdRestaurante

            }).ToList();

            return View(garconsViewModel);
        }

        public async Task<IActionResult> BuscarGarconsPorCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                return BadRequest("Cidade inválida.");
            }

            var garconsDto = await garcomService.BuscarGarconsPorCidade(cidade);

            if (garconsDto == null || garconsDto.Count == 0)
            {
                return NotFound("Nenhum garçom encontrado para a cidade fornecida.");
            }

            var garconsViewModel = garconsDto.Select(static g => new GarcomViewModel
            {
                Id = g.Id,
                Nome = g.Nome,
                Cpf = g.Cpf,
                Telefone1 = g.Telefone1,
                IdRestaurante = g.IdRestaurante
            }).ToList();

            return View(garconsViewModel);
        }

    }
}
