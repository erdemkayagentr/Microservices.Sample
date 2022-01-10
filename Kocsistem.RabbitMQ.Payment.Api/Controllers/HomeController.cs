using System;
using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Payment.Application.Interfaces;
using Kocsistem.RabbitMQ.Payment.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kocsistem.RabbitMQ.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IPaymentService _paymentService;

        public HomeController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("addpayment")]
        public async Task<IActionResult> AddPayment(PaymentDetailModel model)
        {
            try
            {
                await _paymentService.Add(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
            return Ok(true);
        }

        [HttpGet("getDeneme")]
        public IActionResult GetDeneme()
        {
            return Ok("Merhaba Dünya");
        }
    }
}
