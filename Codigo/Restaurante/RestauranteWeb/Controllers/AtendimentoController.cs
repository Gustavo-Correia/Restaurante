using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;

namespace RestauranteWeb.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly IAtendimentoService atendimento;
        private readonly IMapper mapper;

        public AtendimentoController(IAtendimentoService atendimento, IMapper mapper)
        {
            this.atendimento = atendimento;
            this.mapper = mapper;
        }
        // GET: AtendimentoController
        public ActionResult Index()
        {
            var listaAtendimento = atendimento.GetAll();
            var AtendimentoViewModel = mapper.Map<List<AtendimentoViewModel>>(listaAtendimento);
            return View(AtendimentoViewModel);
        }
        // GET: AtendimentoController/Create
        public ActionResult Create()
        {
            var Atendimentoview = new AtendimentoViewModel
            {
                Id = 1
            };
            return View(Atendimentoview);
        }
        // POST: AtendimentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AtendimentoViewModel atendimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var Atendimento = mapper.Map<Atendimento>(atendimentoViewModel);
                atendimento.Create(Atendimento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AtendimentoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var Atendimento = atendimento.Get(id);
            var AtendimentoViewModel = mapper.Map<AtendimentoViewModel>(Atendimento);
            return View(AtendimentoViewModel);
        }

        // POST:AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AtendimentoViewModel atendimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var atendimento1 = mapper.Map<Atendimento>(atendimentoViewModel);
                atendimento.Edit(atendimento1);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AtendimentoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var Atendimento = atendimento.Get(id);
            var atendimentoViewModel = mapper.Map<AtendimentoViewModel>(atendimento);
            return View(atendimentoViewModel);
        }

        // POST: AtendimentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, AtendimentoViewModel atendimento2)
        {
            atendimento.Delete(atendimento2.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
