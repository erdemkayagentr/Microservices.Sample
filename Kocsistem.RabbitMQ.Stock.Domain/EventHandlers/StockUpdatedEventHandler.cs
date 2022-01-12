using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Domain.Core.Events.Stock;
using Kocsistem.RabbitMQ.Stock.Domain.Commands;
using Kocsistem.RabbitMQ.Stock.Domain.Interfaces;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Domain.EventHandlers
{
    public class StockUpdatedEventHandler : IEventHandler<StockUpdatedEvent>
    {
        private readonly IStockDetailRepository _stockDetailRepository;
        private readonly IEventBus _eventBus;

        public StockUpdatedEventHandler(IStockDetailRepository stockDetailRepository, IEventBus eventBus)
        {
            _stockDetailRepository = stockDetailRepository;
            _eventBus = eventBus;
        }

        public async Task Handle(StockUpdatedEvent @event)
        {
            var stock = await _stockDetailRepository.GetStockDetail(@event.StockId);
            if (stock != null && (stock.StockQuantity - @event.SalesQuantity) > -1)
            {
                stock.StockQuantity = stock.StockQuantity - @event.SalesQuantity;
                _stockDetailRepository.Update(stock);

                await _eventBus.SendCommand(new OrderSucceededCommand(@event.OrderID));
            }
            else
            {
                await _eventBus.SendCommand(new OrderRejectedCommand(@event.OrderID));
            }

        }
    }
}
