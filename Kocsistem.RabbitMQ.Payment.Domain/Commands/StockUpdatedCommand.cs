using Kocsistem.RabbitMQ.Domain.Core.Commands;
using System;

namespace Kocsistem.RabbitMQ.Payment.Domain.Commands
{
    public class StockUpdatedCommand : Command
    {
        public Guid StockId { get; set; }
        public Guid OrderId { get; set; }
        public Guid PaymentId { get; set; }
        public int SalesQuantity { get; set; }

        public StockUpdatedCommand(Guid stockId,Guid orderId, Guid paymentId, int salesQuantity)
        {
            StockId = stockId;
            OrderId = orderId;
            PaymentId = paymentId;
            SalesQuantity = salesQuantity;
        }
    }
}
