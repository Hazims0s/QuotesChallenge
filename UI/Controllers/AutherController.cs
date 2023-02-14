using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Client.DTOs.AutherDTOs;
using Client.Interfaces;
using UI.Interfaces;

namespace UI.Controllers
{
    [Authorize]
    public class AutherController : Controller
    {
        private readonly IAutherService autherService;

        public AutherController(IAutherService autherService)
        {
            this.autherService = autherService;
        }
        // GET: AutherController
        public  async Task<IActionResult> Index()
        {
            CancellationToken ss = new CancellationToken();
            var s = await autherService.GetAuthers(ss);
            return View(s);
        }

        // GET: AutherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddAutherDTO collection)
        {
            try
            {
                autherService.AddAuther(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutherController/Edit/5
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

        // GET: AutherController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: AutherController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id )
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
