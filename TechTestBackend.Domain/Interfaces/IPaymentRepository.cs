using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestBackend.Domain.Entities;

namespace TechTestBackend.Domain.Interfaces
{
    public interface IPaymentRepository : ITechTestBackendRepository<Payment>
    {
        Task<Payment> ProcessPayment(Payment payment);
    }
}
