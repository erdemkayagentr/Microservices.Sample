using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kocsistem.RabbitMQ.Stock.Domain.Entities
{
    public class StockDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public decimal PieceAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
