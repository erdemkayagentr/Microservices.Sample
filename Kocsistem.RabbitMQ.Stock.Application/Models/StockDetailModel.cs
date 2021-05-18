using System;

namespace Kocsistem.RabbitMQ.Stock.Application.Models
{
    public class StockDetailModel
    {
        public string ProductName { get; set; }
        public int Piece { get; set; }
        public DateTime Date { get; set; }

        public StockDetailModel()
        {
            Date = DateTime.Now;
        }
    }
}
