using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Domain.Core.Events.Order;
using Kocsistem.RabbitMQ.Stock.Domain.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Domain.CommandHandlers
{
    public class OrderRejectedCommandHandler : IRequestHandler<OrderRejectedCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public OrderRejectedCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(OrderRejectedCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new OrderRejectedEvent(request.OrderId));
            return await Task.FromResult(true);
        }
    }
}
