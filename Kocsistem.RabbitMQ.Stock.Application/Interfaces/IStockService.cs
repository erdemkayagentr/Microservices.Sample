using Kocsistem.RabbitMQ.Stock.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Application.Interfaces
{
    public interface IStockService
    {
        IEnumerable<StockDetailModel> GetAllStocks();
        Task<bool> Add(StockDetailModel stockDetail);
        Task<bool> Update(StockSalesQuantity stockSalesQuantity);
        Task<StockDetailModel> GetStockDetail(Guid id);
    }
}
