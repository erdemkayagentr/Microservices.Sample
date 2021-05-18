using Kocsistem.RabbitMQ.Stock.Application.Interfaces;
using Kocsistem.RabbitMQ.Stock.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Stock.Domain.Interfaces;

namespace Kocsistem.RabbitMQ.Stock.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockDetailRepository _stockDetailRepository;
        private readonly IEventBus _eventBus;

        public StockService(IStockDetailRepository stockDetailRepository, IEventBus eventBus)
        {
            _stockDetailRepository = stockDetailRepository;
            _eventBus = eventBus;
        }

        public Task<bool> Add(StockDetailModel stockDetail)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<StockDetailModel> GetAllStocks()
        {
            return _stockDetailRepository.GetAllStocks().Select(x => new StockDetailModel()
            {
                Piece = x.Piece,
                ProductName = x.ProductName,
                Date = x.Date
            });
        }

        public async Task<StockDetailModel> GetStockDetail(Guid id)
        {
            var stock = await _stockDetailRepository.GetStockDetail(id);
            var result = new StockDetailModel
            {
                Piece = stock.Piece,
                ProductName = stock.ProductName,
                Date = stock.Date
            };
            return result;
        }

        public async Task<bool> Update(StockDetailSubstruct stockDetail)
        {
            var stock = await _stockDetailRepository.GetStockDetail(stockDetail.Id);
            if (stock != null)
            {
                stock.Piece--;
                _stockDetailRepository.Update(stock);
            }

            return true;
        }
    }
}
