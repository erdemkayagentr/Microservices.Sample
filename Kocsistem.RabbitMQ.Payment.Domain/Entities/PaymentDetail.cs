using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kocsistem.RabbitMQ.Payment.Domain.Entities
{
    public class PaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }
        public Guid StockId { get; set; }
        public string PaymentRate { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayDate { get; set; }

        public PaymentDetail()
        {
            PayDate = DateTime.Now;
        }
    }
}
