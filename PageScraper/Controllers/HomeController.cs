using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PageScraper.Models;
using PageScraper.Interfaces;

namespace PageScraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebPageHTMLExtracor _webPageHTMLExtracor;
        private readonly IHTMLSerializer _HTMLSerializer;
        public HomeController(IWebPageHTMLExtracor webPageHTMLExtracor, IHTMLSerializer HtmlSerializer)
        {
            _webPageHTMLExtracor = webPageHTMLExtracor;
            _HTMLSerializer = HtmlSerializer;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetHTMLFromWebPage(string url)
        {
            ViewBag.html = _webPageHTMLExtracor.TryGetWebPageHTML(url).pageData;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
