using Kocsistem.RabbitMQ.Customers.Data.Contexts;
using Kocsistem.RabbitMQ.Infras.IOC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Kocsistem.RabbitMQ.Customers.Api
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CustomerDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("CustomerDbConnection"));
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers Microservice", Version = "v1" });
            });
            //services.AddMediatR(typeof(Startup));
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

        }
    }
}
