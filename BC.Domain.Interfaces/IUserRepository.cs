using System;
using BC.Domain.Core;

namespace BC.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>, IDisposable
    {

    }
}
