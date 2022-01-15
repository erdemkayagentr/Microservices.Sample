using Kocsistem.RabbitMQ.Customers.Domain.Entities;

namespace Kocsistem.RabbitMQ.Customers.Domain.Interfaces
{
    public interface ICustomersRepository
    {
        IEnumerable<CustomersTable> GetAllCustomers();
        Task Add(CustomersTable customersTable);
        void Update(CustomersTable customersTable);
        Task<CustomersTable> GetCustomerById(Guid id);
        Task Delete(CustomersTable customersTable);
    }
}
