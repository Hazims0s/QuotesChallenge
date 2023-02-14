using Client.DTOs.QuotesDTOs;
using Client.Interfaces;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteService _quoteService;
        private readonly IAutherService _autherService;

        public QuoteController(IQuoteService quoteService,IAutherService autherService)
        {
            _quoteService = quoteService;
            _autherService = autherService;
        }
        // GET: QuoteController
        public async Task<IActionResult> Index()
        {
            var qouts = await _quoteService.GetQuotes();
            return View(qouts);
        }
        [Route("ByAuther/{id}")]
        public async Task<IActionResult> ByAuther(Guid id)
        {
            var qouts = await _quoteService.GetQuoteByAuther(id);
            return View(qouts);
        }

        // GET: QuoteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: QuoteController/Create
        public   async Task<IActionResult> Create()
        {
            CancellationToken cancellationToken = CancellationToken.None;
            var autherVm = new AuthersVM { Authers = await _autherService.GetAuthers(cancellationToken) };
            return View(autherVm);
        }

        // POST: QuoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthersVM collection)
        {
            try
            {
                await _quoteService.AddQuote(new AddQuoteDTO { AutherId = collection.AutherId , Text= collection.Text });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuoteController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var quote =await _quoteService.GetQuote(id);
            if (quote != null)
            {
                return View(new UpdateQuoteDTO { Id = quote.Id, Text = quote.Text });
            }
            return View();
        }

        // POST: QuoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UpdateQuoteDTO collection)
        {
            try
            {
                collection.Id = id;
                var quote = _quoteService.UpdateQuote(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QuoteController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            await _quoteService.DeleteQuote(id);
            return RedirectToAction(nameof(Index));
        }

       

    }
}
