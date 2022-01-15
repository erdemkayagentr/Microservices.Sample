using Kocsistem.RabbitMQ.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kocsistem.RabbitMQ.Customers.Data.Contexts
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CustomersTable> CustomersTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
