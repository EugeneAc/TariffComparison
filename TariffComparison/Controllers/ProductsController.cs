using Microsoft.AspNetCore.Mvc;
using TariffComparison.Services.Inrefaces;

namespace TariffComparison.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET products
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_repository.GetAllTariffs());
        }
    }
}
