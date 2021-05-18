using Kocsistem.RabbitMQ.Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Payment.Domain.Interfaces
{
    public interface IPaymentDetailRepository
    {
        IEnumerable<PaymentDetail> GetAllPayments();
        Task Add(PaymentDetail paymentDetail);
        Task<PaymentDetail> GetPaymentDetail(Guid id);
    }
}
