using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteWeb.Models;
using Service;
using System.Diagnostics;

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
        // GET: Pedido
        public ActionResult Index()
        {
            var listaPedido = pedido.GetAll();
            var PedidoViewModel = mapper.Map<List<PedidoViewModel>>(listaPedido);
            return View(PedidoViewModel);
        }
        // GET: Pedido/Create
        public ActionResult Create()
        {
            var Pedidoview = new PedidoViewModel
            {
                IdAtendimento = 1
            };
            return View(Pedidoview);
        }
        // POST: Pedido/Create
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

        // GET: Pedido/Edit/5
        public ActionResult Edit(uint id)
        {
            var Pedido = pedido.Get(id);
            var PedidoViewModel = mapper.Map<PedidoViewModel>(Pedido);
            return View(PedidoViewModel);
        }
        // GET: Pedido/Details/5
        public ActionResult Details(uint id)
        {
            
            var pedido1 = pedido.Get(id);

            if (pedido1 == null)
            {
                return NotFound();
            }

            
            var pedidoViewModel = new PedidoViewModel
            {
                Id = pedido1.Id,
                DataHoraSolicitacao = pedido1.DataHoraSolicitacao,
                DataHoraAtendimento = pedido1.DaaHoraAtendimento,
                IdAtendimento = pedido1.IdAtendimento,
                IdGarcom = pedido1.IdGarcom,
                Status = pedido1.Status
            };

            return View(pedidoViewModel);
        }

        // GET: Pedido/UpdateStatus/5
        public ActionResult UpdateStatus(uint id)
        {
            var pedido1 = pedido.Get(id);
            if (pedido1 == null)
            {
                return NotFound();
            }

            var pedidoViewModel = mapper.Map<PedidoViewModel>(pedido1);
            return View(pedidoViewModel);
        }

        // POST: Pedido/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
              
                pedido.AtualizarStatus(pedidoViewModel.Id, pedidoViewModel.novostatus);

                // Redireciona para a ação Index após a atualização
                return RedirectToAction(nameof(Index));
            }

            // Se o modelo não for válido, retorne a mesma view com o modelo para mostrar os erros
            return View(pedidoViewModel);
        }



        // POST: Pedido/Edit/5
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

        // GET: Pedido/Delete/5
        public ActionResult Delete(uint id)
        {
            var Pedido = pedido.Get(id);
            var pedidoViewModel = mapper.Map<PedidoViewModel>(Pedido);
            return View(pedidoViewModel);
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PedidoViewModel pedido2)
        {
            pedido.Delete(pedido2.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
