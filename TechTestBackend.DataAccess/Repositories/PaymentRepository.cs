using Microsoft.EntityFrameworkCore;
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
        private readonly TechTestBackendContext _dbContext;
        public PaymentRepository(TechTestBackendContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        //public override async Task<Payment> GetById(long id)
        //{
        //    return await _dbContext.Set<Payment>()
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(e => e.PaymentId == id);
        //}
    }
}
