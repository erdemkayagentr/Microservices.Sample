using System;

namespace Kocsistem.RabbitMQ.Domain.Core.Events.Order
{
    public class OrderSucceededEvent : Event
    {
        public Guid OrderId { get; set; }
        public OrderSucceededEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
