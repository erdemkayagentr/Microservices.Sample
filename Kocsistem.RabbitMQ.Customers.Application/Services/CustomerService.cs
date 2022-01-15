using Kocsistem.RabbitMQ.Customers.Application.Interfaces;
using Kocsistem.RabbitMQ.Customers.Application.Models;
using Kocsistem.RabbitMQ.Customers.Domain.Entities;
using Kocsistem.RabbitMQ.Customers.Domain.Interfaces;

namespace Kocsistem.RabbitMQ.Customers.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomerService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<bool> AddCustomer(CustomersTableModel model)
        {
            var entity = new CustomersTable
            {
                Email = model.Email,
                FullName = model.FullName,
                Id = model.Id
            };
            await _customersRepository.Add(entity);
            return true;
        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            var entity = await _customersRepository.GetCustomerById(customerId);
            await _customersRepository.Delete(entity);
            return true;
        }

        public IEnumerable<CustomersTableModel> GetAllCustomers()
        {
            return _customersRepository.GetAllCustomers().Select(x => new CustomersTableModel
            {
                Email = x.Email,
                FullName = x.FullName,
                Id = x.Id
            });
        }

        public async Task<CustomersTableModel> GetCustomerById(Guid customerId)
        {
            var customer = await _customersRepository.GetCustomerById(customerId);
            return new CustomersTableModel
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email
            };
        }

        public bool UpdateCustomer(CustomersTableModel model)
        {
            var entity = new CustomersTable
            {
                Email = model.Email,
                FullName = model.FullName,
                Id = model.Id
            };
            _customersRepository.Update(entity);
            return true;
        }
    }
}
