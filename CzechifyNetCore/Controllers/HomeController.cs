using System;
using CzechifyNetCore.Models;
using CzechifyNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CzechifyNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILanguageAdapter _adapter;
        private readonly IHistoryService _historyService;

        public HomeController(ILogger<HomeController> logger, ILanguageAdapter adapter, IHistoryService historyService)
        {
            _logger = logger;
            _adapter = adapter;
            _historyService = historyService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = _adapter.Title;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Czechify(string text)
        {
            var outputText = _adapter.Adapt(text);

            _logger.LogInformation($"Adapted text: {text} -> {outputText}");
            _historyService.AddRequest(new RecentSearch
            {
                Timestamp = DateTime.Now,
                OriginalText = text,
                AdaptedText = outputText
            });

            return outputText;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
