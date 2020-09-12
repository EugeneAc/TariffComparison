using Microsoft.AspNetCore.Mvc;
using TariffComparison.Services;

namespace TariffComparison.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompareController : Controller
    {
        private readonly ComparisonService _comparisonService;

        public CompareController(ComparisonService comparisonService)
        {
            _comparisonService = comparisonService;
        }


        // GET compare?consumption=3500
        [HttpGet]
        public IActionResult Get(uint consumption)
        {
            return new JsonResult(_comparisonService.CompareTariffs(consumption));
        }
    }
}
