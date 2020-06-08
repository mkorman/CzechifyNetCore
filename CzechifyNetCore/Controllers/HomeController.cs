using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CzechifyNetCore.Models;
using CzechifyNetCore.Services;

namespace CzechifyNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILanguageAdapter _adapter;

        public HomeController(ILogger<HomeController> logger, ILanguageAdapter adapter)
        {
            _logger = logger;
            _adapter = adapter;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Czechify!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Czechify(string text)
        {
            return _adapter.Adapt(text);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
