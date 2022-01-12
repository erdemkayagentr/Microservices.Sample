using Kocsistem.RabbitMQ.Payment.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kocsistem.RabbitMQ.Payment.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> Add(PaymentDetailModel paymentDetail);
        IEnumerable<PaymentDetailModel> GetAllPayments();
    }
}
