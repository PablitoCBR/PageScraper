using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PageScraper.Models;

namespace PageScraper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PageBaseData.DownloadPageData("http://www.zs1brodnica.edu.pl/");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
