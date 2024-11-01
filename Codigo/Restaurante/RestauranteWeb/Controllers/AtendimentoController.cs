using AutoMapper;
using Core.Service;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestauranteWeb.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly IAtendimentoService atendimento;
        private readonly IMesaService mesaService;
        private readonly IMapper mapper;

        public AtendimentoController(IAtendimentoService atendimento, IMesaService mesaService, IMapper mapper)
        {
            this.atendimento = atendimento;
            this.mesaService = mesaService;
            this.mapper = mapper;
        }
        // GET: AtendimentoController
        public ActionResult Index()
        {
            var listaAtendimento = atendimento.GetByStatus("I");
            var AtendimentoViewModel = mapper.Map<List<AtendimentoViewModel>>(listaAtendimento);
            return View(AtendimentoViewModel);
        }
        // GET: AtendimentoController/Create
        public ActionResult Create()
        {
            var mesas = mesaService.GetMesasLivres();
            var Atendimentoview = new AtendimentoViewModel
            {
                SelectMesa = new SelectList(mesas, "Id", "Identificacao", null)
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
                Atendimento.Status = "I";
                atendimento.Create(Atendimento);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AtendimentoController/Edit/5
        public ActionResult Edit(uint id)
        {
            var Atendimento = atendimento.Get(id);
            var AtendimentoViewModel = mapper.Map<AtendimentoViewModel>(Atendimento);
            var mesas = mesaService.GetDtos();
            AtendimentoViewModel.SelectMesa = new SelectList(mesas, "Id", "Identificacao", null);
            return View(AtendimentoViewModel);
        }

        // POST:AtendimentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AtendimentoViewModel atendimentoViewModel)
        {
            var total = atendimentoViewModel.TotalConta + atendimentoViewModel.TotalServico - atendimentoViewModel.TotalDesconto;
            if (total < 0)
            {
                ModelState.AddModelError("Total", "O Valor total da conta não pode ser negativo. Verifique os descontos");
            }
            if (atendimentoViewModel.Status == "C" || atendimentoViewModel.Status == "F")
            {
                atendimentoViewModel.DataHoraFim = DateTime.Now;
            }
            atendimentoViewModel.Total = total;
            if (ModelState.IsValid)
            {
                var atendimento1 = mapper.Map<Atendimento>(atendimentoViewModel);
                atendimento.Edit(atendimento1);
                return RedirectToAction(nameof(Index));
            }
            var mesas = mesaService.GetDtos();
            atendimentoViewModel.SelectMesa = new SelectList(mesas, "Id", "Identificacao", null);
            return View(atendimentoViewModel);
        }

        // GET: AtendimentoController/Delete/5
        public ActionResult Delete(uint id)
        {
            var Atendimento = atendimento.Get(id);
            var AtendimentoViewModel = mapper.Map<AtendimentoViewModel>(Atendimento);
            return View(AtendimentoViewModel);
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
