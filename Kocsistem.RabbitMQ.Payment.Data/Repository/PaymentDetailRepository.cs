using Kocsistem.RabbitMQ.Payment.Data.Context;
using Kocsistem.RabbitMQ.Payment.Domain.Entities;
using Kocsistem.RabbitMQ.Payment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Payment.Data.Repository
{
    public class PaymentDetailRepository : IPaymentDetailRepository
    {
        private readonly PaymentDbContext _context;

        public PaymentDetailRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentDetail> GetAllPayments()
        {
            return _context.PaymentDetail;
        }

        public async Task Add(PaymentDetail paymentDetail)
        {
            await _context.PaymentDetail.AddAsync(paymentDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<PaymentDetail> GetPaymentDetail(Guid id)
        {
            return await _context.PaymentDetail.FindAsync(id);
        }
    }
}
