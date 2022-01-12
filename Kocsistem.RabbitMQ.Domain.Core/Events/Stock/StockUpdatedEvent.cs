using System;

namespace Kocsistem.RabbitMQ.Domain.Core.Events.Stock
{
    public class StockUpdatedEvent : Event
    {
        public Guid PaymentId { get; set; }
        public Guid OrderID { get; set; }
        public Guid StockId { get; set; }
        public int SalesQuantity { get; set; }

        public StockUpdatedEvent(int salesQuantity, Guid orderID, Guid paymentId, Guid stockId)
        {

            this.SalesQuantity = salesQuantity;
            OrderID = orderID;
            PaymentId = paymentId;
            StockId = stockId;
        }
    }
}
