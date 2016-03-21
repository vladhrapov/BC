using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Data.Repository.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BcContext _context;

        public ProjectRepository(BcContext context)
        {
            this._context = context;
        }

        public IQueryable<Entity.Project> All
        {
            get { throw new NotImplementedException(); }
        }

        public Entity.Project Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Entity.Project item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
