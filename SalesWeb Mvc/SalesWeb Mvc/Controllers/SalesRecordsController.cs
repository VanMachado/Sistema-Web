using Microsoft.AspNetCore.Mvc;
using SalesWeb_Mvc.Services;

namespace SalesWeb_Mvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd/MM/yyyy");

            var viewModel = await _salesRecordService.FindByDateAsync(minDate, maxDate);            
            return View(viewModel);
        }

        public IActionResult GroupSearch()
        {
            return View();
        }
    }
}
