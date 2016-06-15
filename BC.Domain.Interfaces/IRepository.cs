using System;
using System.Linq;

namespace BC.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All { get; }
        T Find(Guid id);
        void InsertOrUpdate(T item);
        void Delete(Guid id);
    }
}
