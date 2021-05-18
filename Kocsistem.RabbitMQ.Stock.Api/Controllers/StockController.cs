using Kocsistem.RabbitMQ.Stock.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kocsistem.RabbitMQ.Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {

        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Çalışıyorum");
        }
    }
}
