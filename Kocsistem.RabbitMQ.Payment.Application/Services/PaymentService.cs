using System;
using Kocsistem.RabbitMQ.Payment.Application.Interfaces;
using Kocsistem.RabbitMQ.Payment.Application.Models;
using Kocsistem.RabbitMQ.Payment.Domain.Interfaces;
using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using Kocsistem.RabbitMQ.Payment.Domain.Entities;

namespace Kocsistem.RabbitMQ.Payment.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentDetailRepository _paymentDetailRepository;
        private readonly IEventBus _eventBus;

        public PaymentService(IPaymentDetailRepository paymentDetailRepository, IEventBus eventBus)
        {
            _paymentDetailRepository = paymentDetailRepository;
            _eventBus = eventBus;
        }

        public async Task<bool> Add(PaymentDetailModel paymentDetail)
        {
            PaymentDetail entity = new PaymentDetail
            {
                Amount = paymentDetail.Amount,
                BasketId = paymentDetail.BasketId,
                PaymentRate = paymentDetail.PaymentRate,
                StockId = paymentDetail.StockId
            };
            try
            {
                await _paymentDetailRepository.Add(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            var commandStock = new StockUpdatedCommand(paymentDetail.StockId, true);
            var commandBasket = new BasketUpdatedCommand(paymentDetail.BasketId, true);
            //Rabbite gönderiyoruz
            await _eventBus.SendCommand(commandStock);
            await _eventBus.SendCommand(commandBasket);
            return true;
        }
    }
}
