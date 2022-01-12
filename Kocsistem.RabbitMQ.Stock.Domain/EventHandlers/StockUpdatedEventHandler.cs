using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Domain.Core.Events.Stock;
using Kocsistem.RabbitMQ.Stock.Domain.Interfaces;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Domain.EventHandlers
{
    public class StockUpdatedEventHandler : IEventHandler<StockUpdatedEvent>
    {
        private readonly IStockDetailRepository _stockDetailRepository;

        public StockUpdatedEventHandler(IStockDetailRepository stockDetailRepository)
        {
            _stockDetailRepository = stockDetailRepository;
        }

        public async Task Handle(StockUpdatedEvent @event)
        {
            var stock = await _stockDetailRepository.GetStockDetail(@event.OrderID).ConfigureAwait(false);
            if (stock != null && (stock.StockQuantity - @event.SalesQuantity) > -1)
            {
                stock.StockQuantity--;
                _stockDetailRepository.Update(stock);
            }

        }
    }
}
