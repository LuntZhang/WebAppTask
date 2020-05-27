using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationTask.Entity.Services
{
    public class RepositoryBase<T, TId> : IRepositoryBase<T>, IRepositoryBaseById<T, TId> where T : class
    {
        public DbContext DbContext { get; set; }

        public RepositoryBase(DbContext dbContext)
        {
            DbContext = dbContext;
        }


        public void Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(DbContext.Set<T>().AsEnumerable());
        }

        public Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return Task.FromResult(DbContext.Set<T>().Where(expression).AsEnumerable());
        }

        public async Task<bool> SaveAsyce()
        {
            return await DbContext.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }

        public async Task<T> GetByIdAsyce(TId id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExIstAsync(TId id)
        {
            return await DbContext.Set<T>().FindAsync(id) != null;
        }
    }
}
