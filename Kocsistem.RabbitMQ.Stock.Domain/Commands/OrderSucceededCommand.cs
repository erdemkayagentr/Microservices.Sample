using Kocsistem.RabbitMQ.Domain.Core.Commands;
using System;

namespace Kocsistem.RabbitMQ.Stock.Domain.Commands
{
    public class OrderSucceededCommand : Command
    {
        public Guid OrderId { get; set; }

        public OrderSucceededCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
