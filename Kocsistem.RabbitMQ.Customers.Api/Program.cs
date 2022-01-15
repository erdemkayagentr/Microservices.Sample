using Kocsistem.RabbitMQ.Customers.Data.Contexts;
using Kocsistem.RabbitMQ.Customers.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Kocsistem.RabbitMQ.Customers.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var customerDbContext = services.GetRequiredService<CustomerDbContext>();
                    await customerDbContext.Database.MigrateAsync();
                    await CustomerDbContextSeed.SeedCustomersAsync(customerDbContext);
                }
                catch
                {

                    throw;
                }
            }




            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
