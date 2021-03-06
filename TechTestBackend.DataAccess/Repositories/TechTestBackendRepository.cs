using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechTestBackend.Domain.Interfaces;

namespace TechTestBackend.DataAccess.Repositories
{
    public abstract class TechTestBackendRepository<T> : ITechTestBackendRepository<T> where T : class
    {
        protected readonly TechTestBackendContext _context;
        public TechTestBackendRepository(TechTestBackendContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public abstract Task<T> GetById(long id);

        public async Task<T> Create(T entity)
        {
            var value = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return value.Entity;
        }
        public async Task Update(long id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
