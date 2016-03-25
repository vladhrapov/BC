using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Data.Entity;

namespace BC.Data.Repository.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BcContext _context;

        public ProjectRepository(BcContext context)
        {
            this._context = context;
        }

        public IQueryable<Project> All
        {
            get { return _context.Projects.AsQueryable(); }
        }

        public Project Find(Guid id)
        {
            return _context.Projects.Find(id);
        }

        public void InsertOrUpdate(Project item)
        {
            _context.Projects.AddOrUpdate(item);
        }

        public void Delete(Guid id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id.Equals(id));

            if (project != null)
            {
                _context.Projects.Remove(project);
            }
        }
    }
}
