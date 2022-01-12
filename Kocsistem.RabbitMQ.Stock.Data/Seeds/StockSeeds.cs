using Kocsistem.RabbitMQ.Stock.Data.Context;
using Kocsistem.RabbitMQ.Stock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Stock.Data.Seeds
{
    public sealed class NotifierIdentityDbContextSeed
    {
        public static async Task SeedStockAsync(StockDbContext stockDbContext)
        {
            if (!stockDbContext.StockDetail.Any())
            {
                var entity = new StockDetail
                {
                    Date = DateTime.Now,
                    PieceAmount = 1905,
                    ProductName = "SendeoProduct",
                    StockQuantity = 45
                };

                await stockDbContext.StockDetail.AddAsync(entity);
            }
        }
    }
}
