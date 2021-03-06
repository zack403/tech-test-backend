using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestBackend.Domain.Entities;
using TechTestBackend.Domain.Interfaces;

namespace TechTestBackend.DataAccess.Repositories
{
    public class PaymentStateRepository : TechTestBackendRepository<PaymentState>, IPaymentStateRepository
    {
        private readonly TechTestBackendContext _context;
        public PaymentStateRepository(TechTestBackendContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        //public override async Task<PaymentState> GetById(long id)
        //{
        //    return await _context.Set<PaymentState>()
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(e => e.PaymentId == id);
        //}
    }
}
