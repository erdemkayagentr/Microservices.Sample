using System;
using Kocsistem.RabbitMQ.Domain.Core.Events;

namespace Kocsistem.RabbitMQ.Payment.Domain.Events
{
    public class StockUpdatedEvent : Event
    {
        public Guid Id { get; set; }
        public bool PieceSubstract { get; set; }

        public StockUpdatedEvent(Guid id, bool pieceSubstract)
        {

            this.Id = id;
            this.PieceSubstract = pieceSubstract;
        }
    }
}
