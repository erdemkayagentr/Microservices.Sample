using System;
using System.Collections.Generic;
using System.Text;
using Kocsistem.RabbitMQ.Stock.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kocsistem.RabbitMQ.Stock.Data.Context
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StockDetail> StockDetail { get; set; }
    }
}
