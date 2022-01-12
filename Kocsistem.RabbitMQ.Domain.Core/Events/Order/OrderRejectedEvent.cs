using System;

namespace Kocsistem.RabbitMQ.Domain.Core.Events.Order
{
    public class OrderRejectedEvent : Event
    {
        public Guid OrderId { get; set; }
        public OrderRejectedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
