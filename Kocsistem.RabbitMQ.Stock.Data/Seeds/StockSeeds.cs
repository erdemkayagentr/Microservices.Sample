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
                var entity = new List<StockDetail>
                {
                    new StockDetail
                    {
                        Date = DateTime.Now,
                        PieceAmount = 1905,
                        ProductName = "SendeoProduct",
                        StockQuantity = 45
                    },
                    new StockDetail
                    {
                        Date = DateTime.Now,
                        PieceAmount = 1481,
                        ProductName = "SendeoProduct2",
                        StockQuantity = 10
                    }
                };

                await stockDbContext.StockDetail.AddRangeAsync(entity);
                await stockDbContext.SaveChangesAsync();
            }
        }
    }
}
