using Kocsistem.RabbitMQ.Stock.Data.Context;
using Kocsistem.RabbitMQ.Stock.Data.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var stockDbContext = services.GetRequiredService<StockDbContext>();
                    await stockDbContext.Database.MigrateAsync();
                    await NotifierIdentityDbContextSeed.SeedStockAsync(stockDbContext);
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
