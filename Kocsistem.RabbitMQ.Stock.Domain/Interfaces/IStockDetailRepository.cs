using Kocsistem.RabbitMQ.Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Domain.Interfaces
{
    public interface IStockDetailRepository
    {
        IEnumerable<StockDetail> GetAllStocks();
        Task Add(StockDetail stockDetail);
        void Update(StockDetail stockDetail);
        Task<StockDetail> GetStockDetail(Guid id);
    }
}
