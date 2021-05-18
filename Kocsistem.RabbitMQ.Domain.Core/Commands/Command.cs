using Kocsistem.RabbitMQ.Domain.Core.Events;
using System;

namespace Kocsistem.RabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Date { get; protected set; }

        protected Command()
        {
            Date = DateTime.Now;
        }
    }
}
