using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kocsistem.RabbitMQ.Mvc.Models;
using Kocsistem.RabbitMQ.Payment.Application.Models;
using Newtonsoft.Json;

namespace Kocsistem.RabbitMQ.Mvc.Controllers
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
            //HttpClient _client = new HttpClient();
            //PaymentDetailModel model = new PaymentDetailModel
            //{
            //    StockId = new Guid("0eb532d5-b783-4a0d-9f97-5aa280b45ec9"),
            //    BasketId = new Guid("b809c823-3746-4463-b32f-9418072fe00f"),
            //    Amount = 19.05m,
            //    PaymentRate = "Kredi Kartı"
            //};
            //var uri = "http://localhost:65000/payment/addPayment";
            //var transferContent = new StringContent(JsonConvert.SerializeObject(model),
            //    System.Text.Encoding.UTF8,
            //    "application/json");
            //var response = await _client.PostAsync(uri, transferContent);
            //response.EnsureSuccessStatusCode();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
