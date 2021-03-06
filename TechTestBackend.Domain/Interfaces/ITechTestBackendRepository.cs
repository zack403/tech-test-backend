using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechTestBackend.Domain.Interfaces
{
    public interface ITechTestBackendRepository<T> where T: class
    {
        Task<T> GetById(long id);
        IQueryable<T> GetAll();
        Task<T> Create(T entity);
        Task Update(long id, T entity);
        Task Delete(long id);
    }
}
