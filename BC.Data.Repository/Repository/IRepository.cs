using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
