using Microsoft.AspNetCore.Mvc;
using SalesWeb_Mvc.Services;

namespace SalesWeb_Mvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        
        public IActionResult Index()
        {
            var list = _sellerService.FindaAll();
            return View(list);
        }
    }
}
