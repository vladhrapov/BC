using System;
using System.Data.Entity.Migrations;
using System.Linq;
using BC.Domain.Core;
using BC.Domain.Interfaces;

namespace BC.Infrastructure.Data.Repository
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
            if (item != null)
            {
                _context.Projects.AddOrUpdate(item);
            }
            else
            {
                throw new NullReferenceException("Project is null");
            }

        }

        public void Delete(Guid id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id.Equals(id));

            if (project != null)
            {
                _context.Projects.Remove(project);
            }
            else
            {
                throw new NullReferenceException("There is no such project");
            }
        }
    }
}
