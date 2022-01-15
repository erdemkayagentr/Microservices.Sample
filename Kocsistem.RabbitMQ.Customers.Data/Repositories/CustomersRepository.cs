using Kocsistem.RabbitMQ.Customers.Data.Contexts;
using Kocsistem.RabbitMQ.Customers.Domain.Entities;
using Kocsistem.RabbitMQ.Customers.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kocsistem.RabbitMQ.Customers.Data.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CustomerDbContext _context;
        public CustomersRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public async Task Add(CustomersTable customersTable)
        {
            await _context.AddAsync(customersTable);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CustomersTable customersTable)
        {
            _context.CustomersTable.Remove(customersTable);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<CustomersTable> GetAllCustomers()
        {
            return _context.CustomersTable.AsNoTracking();
        }

        public async Task<CustomersTable> GetCustomerById(Guid id)
        {
            var entity = await _context.CustomersTable.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            return entity;
        }

        public void Update(CustomersTable customersTable)
        {
            _context.CustomersTable.Update(customersTable);
            _context.SaveChanges();
        }
    }
}
