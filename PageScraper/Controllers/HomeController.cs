using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PageScraper.Models;
using PageScraper.Interfaces;

namespace PageScraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebPageHTMLExtracor _webPageHTMLExtracor;
        public HomeController(IWebPageHTMLExtracor webPageHTMLExtracor)
        {
            _webPageHTMLExtracor = webPageHTMLExtracor;
        }
        public IActionResult Index()
        {
            ViewBag.pageBody = _webPageHTMLExtracor.TryGetWebPageHTML("www.zs1brodnica.edu.pl");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
