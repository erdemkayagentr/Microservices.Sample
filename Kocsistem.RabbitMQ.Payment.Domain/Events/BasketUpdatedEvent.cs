using Kocsistem.RabbitMQ.Domain.Core.Events;
using System;

namespace Kocsistem.RabbitMQ.Payment.Domain.Events
{
    public class BasketUpdatedEvent : Event
    {
        public Guid Id { get; set; }
        public bool Ok { get; set; }

        public BasketUpdatedEvent(Guid id, bool ok)
        {

            this.Id = id;
            this.Ok = ok;
        }
    }
}
