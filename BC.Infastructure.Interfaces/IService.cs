using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BC.Infastructure.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> All();
        T FindBy(Expression<Func<T, bool>> predicate);
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}