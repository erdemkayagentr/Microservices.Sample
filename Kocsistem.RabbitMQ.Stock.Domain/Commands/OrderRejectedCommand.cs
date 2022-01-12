using Kocsistem.RabbitMQ.Domain.Core.Commands;
using System;

namespace Kocsistem.RabbitMQ.Stock.Domain.Commands
{
    public class OrderRejectedCommand : Command
    {
        public Guid OrderId { get; set; }

        public OrderRejectedCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
