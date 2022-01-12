using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Domain.Core.Events.Payment;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using Kocsistem.RabbitMQ.Payment.Domain.Interfaces;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Payment.Domain.EventHandlers
{
    public class PaymentCreatedEventHandler : IEventHandler<PaymentCreatedEvent>
    {
        private readonly IPaymentDetailRepository _paymentDetailRepository;
        private readonly IEventBus _eventBus;

        public PaymentCreatedEventHandler(IPaymentDetailRepository paymentDetailRepository, IEventBus eventBus)
        {
            _paymentDetailRepository = paymentDetailRepository;
            _eventBus = eventBus;
        }

        public Task Handle(PaymentCreatedEvent @event)
        {
            var entity = new Entities.PaymentDetail
            {
                Amount = @event.Amount,
                Quantity = @event.Quantity,
                StockId = @event.StockId,
                UserId = @event.UserId,
            };
            _paymentDetailRepository.Add(entity);
            var stockCommand = _eventBus.SendCommand(new StockUpdatedCommand(@event.StockId,@event.OrderId, entity.Id,@event.Quantity));

            return Task.CompletedTask;
        }
    }
}
