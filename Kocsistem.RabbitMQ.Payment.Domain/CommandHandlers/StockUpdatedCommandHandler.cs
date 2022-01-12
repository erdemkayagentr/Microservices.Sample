using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Domain.Core.Events.Stock;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Payment.Domain.CommandHandlers
{
    public class StockUpdatedCommandHandler :IRequestHandler<StockUpdatedCommand,bool>
    {
        private readonly IEventBus _eventBus;

        public StockUpdatedCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(StockUpdatedCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new StockUpdatedEvent(request.SalesQuantity,request.OrderId,request.PaymentId));
            return await Task.FromResult(true);
        }
    }
}
