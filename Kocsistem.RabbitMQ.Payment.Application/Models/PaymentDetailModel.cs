using System;

namespace Kocsistem.RabbitMQ.Payment.Application.Models
{
    public class PaymentDetailModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public Guid StockId { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get { return Amount * Quantity; } }
        public DateTime PayDate { get; set; }
        public bool IsActive { get; set; }

        public PaymentDetailModel()
        {
            IsActive = true;
            PayDate = DateTime.Now;
        }
    }
}
