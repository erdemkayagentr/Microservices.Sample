using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Infras.Bus;
using Kocsistem.RabbitMQ.Payment.Application.Interfaces;
using Kocsistem.RabbitMQ.Payment.Application.Services;
using Kocsistem.RabbitMQ.Payment.Data.Context;
using Kocsistem.RabbitMQ.Payment.Data.Repository;
using Kocsistem.RabbitMQ.Payment.Domain.CommandHandlers;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using Kocsistem.RabbitMQ.Payment.Domain.Events;
using Kocsistem.RabbitMQ.Payment.Domain.Interfaces;
using Kocsistem.RabbitMQ.Stock.Application.Interfaces;
using Kocsistem.RabbitMQ.Stock.Application.Services;
using Kocsistem.RabbitMQ.Stock.Data.Context;
using Kocsistem.RabbitMQ.Stock.Data.Repositories;
using Kocsistem.RabbitMQ.Stock.Domain.EventHandlers;
using Kocsistem.RabbitMQ.Stock.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Kocsistem.RabbitMQ.Infras.IOC
{
    public class Container
    {
        public static void RegisteredServices(IServiceCollection services)
        {
            //Bus
            services.AddSingleton<IEventBus, RabbitmqBus>(s =>
            {
                var scopeFactory = s.GetRequiredService<IServiceScopeFactory>();
                return new RabbitmqBus(s.GetService<IMediator>(), scopeFactory);
            });

            //subscribe
            services.AddTransient<StockUpdatedEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<StockUpdatedEvent>, StockUpdatedEventHandler>();

            //Command
            services.AddTransient<IRequestHandler<StockUpdatedCommand, bool>, StockUpdatedCommandHandler>();
            services.AddTransient<IRequestHandler<BasketUpdatedCommand, bool>, BasketUpdatedCommandHandler>();

            //services
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IStockService, StockService>();

            //Data
            services.AddTransient<IPaymentDetailRepository, PaymentDetailRepository>();
            services.AddTransient<IStockDetailRepository, StockDetailRepository>();

            //Context
            services.AddTransient<PaymentDbContext>();
            services.AddTransient<StockDbContext>();
        }
    }
}
