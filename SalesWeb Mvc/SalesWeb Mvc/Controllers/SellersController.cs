using Microsoft.AspNetCore.Mvc;

namespace SalesWeb_Mvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
