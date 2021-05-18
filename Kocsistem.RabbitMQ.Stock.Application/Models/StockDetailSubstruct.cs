using System;

namespace Kocsistem.RabbitMQ.Stock.Application.Models
{
    public class StockDetailSubstruct
    {
        public Guid Id { get; set; }
        public bool PieceSubstract { get; set; }
    }
}
