using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SalesWeb_Mvc.Models.ViewModels;

namespace SalesWeb_Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Your policy and privacy page!";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application content info page!";            
            return View();
        }    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}