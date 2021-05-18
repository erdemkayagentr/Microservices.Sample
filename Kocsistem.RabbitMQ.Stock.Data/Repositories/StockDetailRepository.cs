using Kocsistem.RabbitMQ.Stock.Domain.Entities;
using Kocsistem.RabbitMQ.Stock.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Stock.Data.Context;

namespace Kocsistem.RabbitMQ.Stock.Data.Repositories
{
    public class StockDetailRepository : IStockDetailRepository
    {
        private readonly StockDbContext _context;

        public StockDetailRepository(StockDbContext context)
        {
            _context = context;
        }
        public async Task Add(StockDetail stockDetail)
        {
            await _context.StockDetail.AddAsync(stockDetail);
        }

        public IEnumerable<StockDetail> GetAllStocks()
        {
            return _context.StockDetail;
        }

        public async Task<StockDetail> GetStockDetail(Guid id)
        {
            return await _context.StockDetail.FindAsync(id);
        }

        public void Update(StockDetail stockDetail)
        {
            _context.Update(stockDetail);
            _context.SaveChanges();
        }
    }
}
