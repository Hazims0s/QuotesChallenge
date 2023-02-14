using Client.Interfaces;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuoteService _quoteService;

        public HomeController(ILogger<HomeController> logger , IQuoteService quoteService)
        {
            _logger = logger;
            _quoteService = quoteService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _quoteService.GetRandomQuote()); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}