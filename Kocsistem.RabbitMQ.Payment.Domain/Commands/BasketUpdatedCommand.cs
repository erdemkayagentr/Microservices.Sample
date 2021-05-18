using Kocsistem.RabbitMQ.Domain.Core.Commands;
using System;

namespace Kocsistem.RabbitMQ.Payment.Domain.Commands
{
    public class BasketUpdatedCommand : Command
    {
        public Guid Id { get; set; }
        public bool Ok { get; set; }

        public BasketUpdatedCommand(Guid id, bool ok)
        {
            this.Id = id;
            this.Ok = ok;
        }
    }
}
