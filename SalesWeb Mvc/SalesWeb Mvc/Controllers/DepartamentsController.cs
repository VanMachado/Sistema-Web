using Microsoft.AspNetCore.Mvc;
using SalesWeb_Mvc.Models;

namespace SalesWeb_Mvc.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departament> list = new List<Departament>();
            list.Add(new Departament (1, "Eletronics"));
            list.Add(new Departament (2, "Fashion"));

            return View(list);
        }
    }
}
