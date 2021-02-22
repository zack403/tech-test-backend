using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestBackend.Domain.Entities;
using TechTestBackend.Domain.Interfaces;

namespace TechTestBackend.DataAccess.Repositories
{
    public class PaymentRepository : TechTestBackendRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(TechTestBackendContext context): base(context)
        {

        }
        public Task<Payment> ProcessPayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
