using System;

namespace Kocsistem.RabbitMQ.Payment.Application.Models
{
    public class PaymentDetailModel
    {
        public Guid BasketId { get; set; }
        public Guid StockId { get; set; }
        public string PaymentRate { get; set; }
        public decimal Amount { get; set; }
    }
}
