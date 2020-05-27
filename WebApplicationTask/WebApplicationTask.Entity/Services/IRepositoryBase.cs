using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationTask.Entity.Services
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAsyce();
    }

    public interface IRepositoryBaseById<T, TId>
    {
        Task<T> GetByIdAsyce(TId id);
        Task<bool> IsExIstAsync(TId id);
    }
}
