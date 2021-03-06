using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestBackend.Dtos;

namespace TechTestBackend.Services
{
    public interface IPaymentRequestService
    {
        Task<PaymentStateDto> Pay(PaymentRequestDto paymentRequestDto);
    }
}
