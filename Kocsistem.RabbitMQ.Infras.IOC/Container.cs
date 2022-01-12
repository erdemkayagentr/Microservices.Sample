using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Domain.Core.Events.Order;
using Kocsistem.RabbitMQ.Domain.Core.Events.Payment;
using Kocsistem.RabbitMQ.Domain.Core.Events.Stock;
using Kocsistem.RabbitMQ.Infras.Bus;
using Kocsistem.RabbitMQ.Order.Application.Interfaces;
using Kocsistem.RabbitMQ.Order.Application.Services;
using Kocsistem.RabbitMQ.Order.Data.Repositories;
using Kocsistem.RabbitMQ.Order.Domain.CommandHandlers;
using Kocsistem.RabbitMQ.Order.Domain.Commands;
using Kocsistem.RabbitMQ.Order.Domain.Context;
using Kocsistem.RabbitMQ.Order.Domain.EventHandlers;
using Kocsistem.RabbitMQ.Order.Domain.Interfaces;
using Kocsistem.RabbitMQ.Payment.Application.Interfaces;
using Kocsistem.RabbitMQ.Payment.Application.Services;
using Kocsistem.RabbitMQ.Payment.Data.Context;
using Kocsistem.RabbitMQ.Payment.Data.Repository;
using Kocsistem.RabbitMQ.Payment.Domain.CommandHandlers;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using Kocsistem.RabbitMQ.Payment.Domain.EventHandlers;
using Kocsistem.RabbitMQ.Payment.Domain.Interfaces;
using Kocsistem.RabbitMQ.Stock.Application.Interfaces;
using Kocsistem.RabbitMQ.Stock.Application.Services;
using Kocsistem.RabbitMQ.Stock.Data.Context;
using Kocsistem.RabbitMQ.Stock.Data.Repositories;
using Kocsistem.RabbitMQ.Stock.Domain.CommandHandlers;
using Kocsistem.RabbitMQ.Stock.Domain.Commands;
using Kocsistem.RabbitMQ.Stock.Domain.EventHandlers;
using Kocsistem.RabbitMQ.Stock.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            services.AddTransient<PaymentCreatedEventHandler>();
            services.AddTransient<OrderSucceededEventHandler>();
            services.AddTransient<OrderRejectedEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<StockUpdatedEvent>, StockUpdatedEventHandler>();
            services.AddTransient<IEventHandler<PaymentCreatedEvent>, PaymentCreatedEventHandler>();
            services.AddTransient<IEventHandler<OrderSucceededEvent>, OrderSucceededEventHandler>();
            services.AddTransient<IEventHandler<OrderRejectedEvent>, OrderRejectedEventHandler>();


            //Command
            services.AddTransient<IRequestHandler<StockUpdatedCommand, bool>, StockUpdatedCommandHandler>();
            services.AddTransient<IRequestHandler<OrderSucceededCommand, bool>, OrderSucceededCommandHandler>();
            services.AddTransient<IRequestHandler<OrderRejectedCommand, bool>, OrderRejectedCommandHandler>();
            services.AddTransient<IRequestHandler<PaymentUpdatedCommand, bool>, PaymentUpdatedCommandHandler>();

            //services
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IOrderService, OrderService>();

            //Data
            services.AddTransient<IPaymentDetailRepository, PaymentDetailRepository>();
            services.AddTransient<IStockDetailRepository, StockDetailRepository>();
            services.AddTransient<IOrderTableRepository, OrderTableRepository>();

            //Context
            services.AddTransient<PaymentDbContext>();
            services.AddTransient<StockDbContext>();
            services.AddTransient<OrderDbContext>();
        }
    }
}
