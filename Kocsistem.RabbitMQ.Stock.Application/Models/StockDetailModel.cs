using System;

namespace Kocsistem.RabbitMQ.Stock.Application.Models
{
    public class StockDetailModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int StockQuantity { get; set; }
        public decimal PieceAmount { get; set; }
        public DateTime Date { get; set; }

        public StockDetailModel()
        {
            Date = DateTime.Now;
        }
    }
}
