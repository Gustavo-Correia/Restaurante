using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteWeb.Controllers
{
    public class ItemcardapioController : Controller
    {
        // GET: ItemcardapioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ItemcardapioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemcardapioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemcardapioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemcardapioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemcardapioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemcardapioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemcardapioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
