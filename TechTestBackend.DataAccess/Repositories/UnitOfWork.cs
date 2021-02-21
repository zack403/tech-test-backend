using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTestBackend.Domain.Interfaces;

namespace TechTestBackend.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechTestBackendContext _context;
        public UnitOfWork(TechTestBackendContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
