using System;
using System.Collections.Generic;
using System.Text;
using TechTestBackend.Dtos;

namespace TechTestBackend.Gateways
{
    public interface IPaymentGateway
    {
        PaymentStateDto ProcessPayment(PaymentRequestDto paymentRequest);
    }
}
