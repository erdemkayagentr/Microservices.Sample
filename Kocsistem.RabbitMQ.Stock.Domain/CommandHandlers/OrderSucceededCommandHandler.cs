using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Domain.Core.Events.Order;
using Kocsistem.RabbitMQ.Stock.Domain.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Domain.CommandHandlers
{
    public class OrderSucceededCommandHandler : IRequestHandler<OrderSucceededCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public OrderSucceededCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(OrderSucceededCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new OrderSucceededEvent(request.OrderId));
            return await Task.FromResult(true);
        }
    }
}
