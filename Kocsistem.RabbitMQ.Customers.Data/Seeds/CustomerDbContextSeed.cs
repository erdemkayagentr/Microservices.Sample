using Kocsistem.RabbitMQ.Customers.Data.Contexts;
using Kocsistem.RabbitMQ.Customers.Domain.Entities;

namespace Kocsistem.RabbitMQ.Customers.Data.Seeds
{
    public sealed class CustomerDbContextSeed
    {
        public static async Task SeedCustomersAsync(CustomerDbContext context)
        {
            if (!context.CustomersTable.Any())
            {
                var entity = new List<CustomersTable>
                {
                    new CustomersTable
                    {
                        Email = "mail@erdemkaya.gen.tr",
                        FullName ="Erdem Kaya"
                    },
                    new CustomersTable
                    {
                        Email = "sendeo@erdemkaya.gen.tr",
                        FullName ="Sendeo"
                    }
                };

                await context.CustomersTable.AddRangeAsync(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
