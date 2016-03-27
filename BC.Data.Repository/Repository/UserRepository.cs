using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Data.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BcContext _context;

        public UserRepository(BcContext context)
        {
            this._context = context;
        }

        public IQueryable<Entity.User> All
        {
            get { return _context.Users.AsQueryable(); }
        }

        public Entity.User Find(Guid id)
        {
            return _context.Users.Find(id);
        }

        public void InsertOrUpdate(Entity.User item)
        {
            _context.Users.AddOrUpdate(item);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id.Equals(id));

            if (user != null)
            {
                _context.Users.Remove(user);
            }
            _context.SaveChanges();
        }
    }
}
