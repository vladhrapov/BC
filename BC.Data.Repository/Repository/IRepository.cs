using System;
using System.Collections.Generic;
using System.Linq;

namespace BC.Data.Repository.Repository
{
    public interface IRepository<T> where T : class 
    {
        IQueryable<T> All { get; }
        T Find(int id);
        void InsertOrUpdate(T item);
        void Delete(int id);
    }
}
