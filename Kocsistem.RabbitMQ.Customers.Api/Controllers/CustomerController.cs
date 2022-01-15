using Kocsistem.RabbitMQ.Customers.Application.Interfaces;
using Kocsistem.RabbitMQ.Customers.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kocsistem.RabbitMQ.Customers.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcustomers")]
        public IEnumerable<CustomersTableModel> GetCustomers()
        {
            return _customerService.GetAllCustomers();
        }
        /// <summary>
        /// Get Customer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getcustomerbyid")]
        public async Task<CustomersTableModel> GetCustomerById(Guid id)
        {
            return await _customerService.GetCustomerById(id);
        }
    }
}
