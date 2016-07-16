using System;
using System.Collections.Generic;

namespace BC.Infastructure.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Add(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}