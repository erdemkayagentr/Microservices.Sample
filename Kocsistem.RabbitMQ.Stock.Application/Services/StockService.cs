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

        public StockService(IStockDetailRepository stockDetailRepository)
        {
            _stockDetailRepository = stockDetailRepository;
        }

        public Task<bool> Add(StockDetailModel stockDetail)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<StockDetailModel> GetAllStocks()
        {
            return _stockDetailRepository.GetAllStocks().Select(x => new StockDetailModel()
            {
                Id = x.Id,
                StockQuantity = x.StockQuantity,
                ProductName = x.ProductName,
                Date = x.Date,
                PieceAmount = x.PieceAmount
            });
        }

        public async Task<StockDetailModel> GetStockDetail(Guid id)
        {
            var stock = await _stockDetailRepository.GetStockDetail(id);
            var result = new StockDetailModel
            {
                StockQuantity = stock.StockQuantity,
                ProductName = stock.ProductName,
                PieceAmount= stock.PieceAmount,
                Date = stock.Date,
                Id = stock.Id
            };
            return result;
        }

        public async Task<bool> Update(StockSalesQuantity stockSalesQuantity)
        {
            var stock = await _stockDetailRepository.GetStockDetail(stockSalesQuantity.Id);
            if (stock != null)
            {
                stock.StockQuantity = stock.StockQuantity - stockSalesQuantity.Quantity;
                if(stock.StockQuantity > -1)
                {
                    _stockDetailRepository.Update(stock);
                }
            }

            return true;
        }
    }
}
