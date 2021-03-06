using System;
using System.Collections.Generic;
using System.Text;
using TechTestBackend.API.Dtos;

namespace TechTestBackend.Gateways
{
    public interface IPaymentGateway
    {
        PaymentStateDto ProcessPayment(PaymentDto paymentRequest);
    }
}
