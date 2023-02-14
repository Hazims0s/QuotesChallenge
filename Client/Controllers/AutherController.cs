using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Client.DTOs.AutherDTOs;
using Client.Interfaces;
 
namespace Client.Controllers
{
    [Authorize]
    public class AutherController : Controller
    {
        private readonly IAutherService _autherService;

        public AutherController(IAutherService autherService)
        {
           _autherService = autherService;
        }
        // GET: AutherController
        public  async Task<IActionResult> Index()
        {
            CancellationToken ss = new CancellationToken();
            var s = await _autherService.GetAuthers(ss);
            return View(s);
        }

 

        // GET: AutherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAutherDTO collection)
        {
            try
            {
               await  _autherService.AddAuther(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutherController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            
            return View(await _autherService.GetAuther(id));
        }

        // POST: AutherController/Edit/5
        [HttpPost]
         public async Task<IActionResult> Edit(Guid id, AutherDTO auther)
        {
            try
            {
              await  _autherService.UpdateAuther(id, auther);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
         

        // POST: AutherController/Delete/5
        [HttpGet]
         public async Task<IActionResult> Delete(Guid id )
        {
            try
            {
                 await _autherService.DeleteAuther(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
