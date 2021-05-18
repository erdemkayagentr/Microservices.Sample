using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Stock.Domain.Interfaces;
using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Payment.Domain.Events;

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
            var stock = await  _stockDetailRepository.GetStockDetail(@event.Id).ConfigureAwait(false);
            if (stock != null)
            {
                stock.Piece--;
                _stockDetailRepository.Update(stock);
            }

        }
    }
}
