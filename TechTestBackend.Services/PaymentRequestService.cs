
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTestBackend.Domain.Entities;
using TechTestBackend.Domain.Enum;
using TechTestBackend.Domain.Interfaces;
using TechTestBackend.Dtos;
using TechTestBackend.Gateways;

namespace TechTestBackend.Services
{
    public class PaymentRequestService : IPaymentRequestService
    {
        private readonly  ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentStateRepository _paymentStateRepository;
        public PaymentRequestService(ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway, IPaymentRepository paymentRepository, IPaymentStateRepository paymentStateRepository)
        {
            
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;
            _paymentRepository = paymentRepository;
            _paymentStateRepository = paymentStateRepository;
        }
        public async Task<PaymentStateDto> Pay(PaymentRequestDto paymentRequestDto)
        {
            var paymentEntity = JObject.FromObject(paymentRequestDto, new Newtonsoft.Json.JsonSerializer { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }).ToObject<Payment>();
            paymentEntity = await _paymentRepository.Create(paymentEntity);

            var paymentStateEntity = new PaymentState() { Payment = paymentEntity, PaymentId = paymentEntity.PaymentId, CreatedDate = DateTime.Now, State = PaymentStateEnum.Pending.ToString() };
            paymentStateEntity = await _paymentStateRepository.Create(paymentStateEntity);

            //save to db here
            //send request to various gateway here
            if (paymentRequestDto.Amount <= 20)
            {
                var paymentStateDto = await ProcessPaymentStateDto(_cheapPaymentGateway, paymentRequestDto, paymentEntity);
                return paymentStateDto;
            }
            else if (paymentRequestDto.Amount > 20 && paymentRequestDto.Amount <= 500)
            {
                PaymentStateDto paymentStateDto = new PaymentStateDto() { PaymentState = PaymentStateEnum.Failed, PaymentStateDate = DateTime.Now };
                int tryCount = 0;
                try
                {
                    paymentStateDto = await ProcessPaymentStateDto(_expensivePaymentGateway, paymentRequestDto, paymentEntity);
                    if (paymentStateDto != null && paymentStateDto.PaymentState == PaymentStateEnum.Processed)
                        return paymentStateDto;
                    else
                    {
                        tryCount++;
                        paymentStateDto = await ProcessPaymentStateDto(_cheapPaymentGateway, paymentRequestDto, paymentEntity);
                        return paymentStateDto;
                    }
                }
                catch (Exception ex)
                {
                    //log exception
                    if (tryCount == 0)
                    {
                        paymentStateDto = await ProcessPaymentStateDto(_cheapPaymentGateway, paymentRequestDto, paymentEntity);
                        return paymentStateDto;
                    }
                }
                return paymentStateDto;
            }
            else
            {
                int tryCount = 0;
                PaymentStateDto paymentStateDto = new PaymentStateDto() { PaymentState = PaymentStateEnum.Failed, PaymentStateDate = DateTime.Now }; ;
                while (tryCount < 3)
                {
                    try
                    {
                        paymentStateDto = await ProcessPaymentStateDto(_expensivePaymentGateway, paymentRequestDto, paymentEntity);
                        if (paymentStateDto != null && paymentStateDto.PaymentState == PaymentStateEnum.Processed)
                            return paymentStateDto;
                    }
                    catch (Exception ex)
                    {
                        //log error
                    }
                    finally
                    {
                        tryCount++;
                    }
                }
                return paymentStateDto;
            }
            throw new Exception("Payment could not be processed");
        }

        private async Task<PaymentStateDto> ProcessPaymentStateDto(IPaymentGateway paymentGateway, PaymentRequestDto paymentRequestDto, Payment paymentEntity)
        {
            var paymentStateDto = paymentGateway.ProcessPayment(paymentRequestDto);
            var paymentStateEntityProcessed = new PaymentState() { Payment = paymentEntity, PaymentId = paymentEntity.PaymentId, CreatedDate = paymentStateDto.PaymentStateDate, State = paymentStateDto.PaymentState.ToString() };
            paymentStateEntityProcessed = await _paymentStateRepository.Create(paymentStateEntityProcessed);
            return paymentStateDto;
        }
    }
}
