using System;
using System.Linq;
using BC.Domain.Interfaces;

namespace BC.Infrastructure.Data
{
    public abstract class  GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public virtual void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, System.Linq.Expressions.Expression<Func<T, bool>> filter = null, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }
    }
}
