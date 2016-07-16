using System;
using System.Linq;
using System.Linq.Expressions;

namespace BC.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {
        IQueryable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes);

        IQueryable<T> FindBy(Guid id);

        void Add(T entity);
        void Delete(Guid id);
        void Edit(T entity);
        void Save();
    }
}