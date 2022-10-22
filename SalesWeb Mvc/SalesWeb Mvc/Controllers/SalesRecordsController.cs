using Microsoft.AspNetCore.Mvc;

namespace SalesWeb_Mvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }

        public IActionResult GroupSearch()
        {
            return View();
        }
    }
}
