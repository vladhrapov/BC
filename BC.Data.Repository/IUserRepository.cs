using System;
using System.Collections.Generic;
using BC.Data.Entity;

namespace BC.Data.Repository
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid studentId);
        void AddUser(User user);
        void DeleteUser(Guid userId);
        void UpdateUser(User user);
        void Save();
    }
}
