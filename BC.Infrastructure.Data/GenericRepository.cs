using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BC.Domain.Interfaces;

namespace BC.Infrastructure.Data
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();

        public C Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public List<T> All( IOrderedQueryable<T> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities.Set<T>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes.Any())
            {
                includes.ToList().ForEach(i => query = query.Include(i));
            }

            //TODO Fix bug
            //if (orderBy != null)
            //{
            //    query = orderBy(query);
            //}

            return query.ToList();
        }

        public T FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities.Set<T>().AsNoTracking();

            if (includes.Any())
            {
                includes.ToList().ForEach(i => query = query.Include(i));
            }

            return query.FirstOrDefault(predicate);
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }
    
        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public virtual void Dispose()
        {
            _entities.Dispose();
        }

       
    }
}
