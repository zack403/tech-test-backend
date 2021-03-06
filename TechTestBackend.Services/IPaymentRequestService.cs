using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestBackend.API.Dtos;

namespace TechTestBackend.Services
{
    public interface IPaymentRequestService
    {
        Task<PaymentStateDto> Pay(PaymentDto paymentRequestDto);
    }
}
