using Kocsistem.RabbitMQ.Infras.IOC;
using Kocsistem.RabbitMQ.Payment.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Kocsistem.RabbitMQ.Payment.Api
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
            services.AddDbContext<PaymentDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("PaymentDbConnection"));
            });
            services.AddCors(options =>
            {
                options.AddPolicy("Allow",
                    builder => { builder.AllowAnyOrigin(); });
            });
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking Microservice", Version = "v1" });
            });
            services.AddMediatR(typeof(Startup));
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
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
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("v1/swagger.json", "Payment Microservice v1");

            });

        }
    }
}
