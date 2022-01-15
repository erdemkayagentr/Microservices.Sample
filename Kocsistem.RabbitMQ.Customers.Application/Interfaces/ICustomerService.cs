using Kocsistem.RabbitMQ.Customers.Application.Models;

namespace Kocsistem.RabbitMQ.Customers.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(CustomersTableModel model);
        bool UpdateCustomer(CustomersTableModel model);
        Task<bool> DeleteCustomer(Guid customerId);
        Task<CustomersTableModel> GetCustomerById(Guid customerId);
        IEnumerable<CustomersTableModel> GetAllCustomers();
    }
}
