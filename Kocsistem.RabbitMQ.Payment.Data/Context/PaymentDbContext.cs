using System;
using Kocsistem.RabbitMQ.Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kocsistem.RabbitMQ.Payment.Data.Context
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PaymentDetail> PaymentDetail { get; set; }
    }
}
