using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Data.Entity;

namespace BC.Data.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private bool disposed = false;
        private BcContext context;

        public UserRepository(BcContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(Guid studentId)
        {
            return context.Users.Find(studentId);
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(Guid userId)
        {
            var user = context.Users.Find(userId);
            context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
