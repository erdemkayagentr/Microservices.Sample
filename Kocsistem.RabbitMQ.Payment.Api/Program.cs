using Kocsistem.RabbitMQ.Payment.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Payment.Api
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
                    var paymentDbContext = services.GetRequiredService<PaymentDbContext>();
                    await paymentDbContext.Database.MigrateAsync();
                }
                catch
                {

                    throw;
                }
            }




            host.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseUrls("http://localhost:80")
                .UseStartup<Startup>();
    }
}
