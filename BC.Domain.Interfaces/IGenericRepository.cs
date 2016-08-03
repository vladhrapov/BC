using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BC.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> All(IOrderedQueryable<T> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes);

        T FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}