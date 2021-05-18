using System;

namespace Kocsistem.RabbitMQ.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime Date { get; protected set; }

        protected Event()
        {
            Date = DateTime.Now;
        }
    }
}
