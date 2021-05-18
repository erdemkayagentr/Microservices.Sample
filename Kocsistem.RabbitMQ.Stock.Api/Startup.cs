using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Infras.IOC;
using Kocsistem.RabbitMQ.Payment.Domain.Events;
using Kocsistem.RabbitMQ.Stock.Data.Context;
using Kocsistem.RabbitMQ.Stock.Domain.EventHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Kocsistem.RabbitMQ.Stock.Api
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StockDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("StockDbConnection"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Allow",
                    builder => { builder.AllowAnyOrigin(); });
            });

            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stock Microservice", Version = "v1" });
            });

            RegisteredServices(services);
        }

        private void RegisteredServices(IServiceCollection services)
        {
            Container.RegisteredServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("v1/swagger.json", "Stock Microservice v1");
            });
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<StockUpdatedEvent, StockUpdatedEventHandler>();
        }
    }
}
