using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class QuoteController : Controller
    {
        // GET: QuoteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuoteController/Create
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

        // GET: QuoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuoteController/Edit/5
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

        // GET: QuoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuoteController/Delete/5
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
