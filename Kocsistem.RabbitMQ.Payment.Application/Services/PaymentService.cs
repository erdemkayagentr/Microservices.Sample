using System;
using Kocsistem.RabbitMQ.Payment.Application.Interfaces;
using Kocsistem.RabbitMQ.Payment.Application.Models;
using Kocsistem.RabbitMQ.Payment.Domain.Interfaces;
using System.Threading.Tasks;
using Kocsistem.RabbitMQ.Domain.Core.Bus;
using Kocsistem.RabbitMQ.Payment.Domain.Commands;
using Kocsistem.RabbitMQ.Payment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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
                PayDate = paymentDetail.PayDate,
                Quantity = paymentDetail.Quantity,
                StockId = paymentDetail.StockId,
                UserId = paymentDetail.UserId
            };
            try
            {
                await _paymentDetailRepository.Add(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            var commandStock = new StockUpdatedCommand(paymentDetail.StockId, paymentDetail.OrderId, paymentDetail.Id, paymentDetail.Quantity);
            // var commandBasket = new BasketUpdatedCommand(paymentDetail.BasketId, true);
            //Rabbite gönderiyoruz
            await _eventBus.SendCommand(commandStock);
            //   await _eventBus.SendCommand(commandBasket);
            return true;
        }

        public IEnumerable<PaymentDetailModel> GetAllPayments()
        {
            var list = _paymentDetailRepository.GetAllPayments().Select(x => new PaymentDetailModel
            {
                Id = x.Id,
                Amount = x.Amount,
                IsActive = x.IsActive,
                OrderId = x.OrderId,
                PayDate = x.PayDate,
                Quantity = x.Quantity,
                StockId = x.StockId,
                UserId = x.UserId
            });

            return list;
        }
    }
}
