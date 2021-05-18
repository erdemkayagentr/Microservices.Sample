using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using Kocsistem.RabbitMQ.Payment.Domain.Events;
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
            _eventBus.Publish(new StockUpdatedEvent(request.Id,request.PieceSubstract));
            return await Task.FromResult(true);
        }
    }
}
