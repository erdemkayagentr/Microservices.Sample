using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Domain.Core.Events;

namespace Kocsistem.RabbitMQ.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent :Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
