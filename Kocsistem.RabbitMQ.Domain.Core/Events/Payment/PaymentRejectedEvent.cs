using System;

namespace Kocsistem.RabbitMQ.Domain.Core.Events.Payment
{
    public class PaymentRejectedEvent : Event
    {
        public Guid PaymentId { get; set; }
        public PaymentRejectedEvent(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
