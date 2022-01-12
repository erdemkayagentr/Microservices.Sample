using Kocsistem.RabbitMQ.Stock.Application.Interfaces;
using Kocsistem.RabbitMQ.Stock.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kocsistem.RabbitMQ.Stock.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {

        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("getStockProducts")]
        public IEnumerable<StockDetailModel> GetStockProducts()
        {
            var model = _stockService.GetAllStocks();
            return model;
        }
    }
}