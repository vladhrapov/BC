using System;
using System.Collections.Generic;
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
            get { throw new NotImplementedException(); }
        }

        public Entity.User Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Entity.User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
