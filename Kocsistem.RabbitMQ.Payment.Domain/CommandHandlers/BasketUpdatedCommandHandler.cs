using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using Kocsistem.RabbitMQ.Payment.Domain.Events;
using MediatR;

namespace Kocsistem.RabbitMQ.Payment.Domain.CommandHandlers
{
    public class BasketUpdatedCommandHandler : IRequestHandler<BasketUpdatedCommand,bool>
    {
        private readonly IEventBus _eventBus;

        public BasketUpdatedCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<bool> Handle(BasketUpdatedCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new BasketUpdatedEvent(request.Id, request.Ok));
            return await Task.FromResult(true);
        }
    }
}
