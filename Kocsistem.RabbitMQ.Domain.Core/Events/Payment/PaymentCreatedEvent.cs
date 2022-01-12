using System;

namespace Kocsistem.RabbitMQ.Domain.Core.Events.Payment
{
    public class PaymentCreatedEvent : Event
    {
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }

        public PaymentCreatedEvent(Guid orderId, Guid stockId, decimal amount, int quantity, Guid userId)
        {
            OrderId = orderId;
            StockId = stockId;
            Amount = amount;
            Quantity = quantity;
            UserId = userId;
        }
    }
}
