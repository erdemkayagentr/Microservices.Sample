using Kocsistem.RabbitMQ.Domain.Core.Commands;
using System;

namespace Kocsistem.RabbitMQ.Payment.Domain.Commands
{
    public class StockUpdatedCommand : Command
    {
        public Guid Id { get; set; }
        public bool PieceSubstract { get; set; }

        public StockUpdatedCommand(Guid id,bool pieceSubstract)
        {
            this.Id = id;
            this.PieceSubstract = pieceSubstract;
        }
    }
}
