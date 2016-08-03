using System;
using System.Data.Entity.Migrations;
using System.Linq;
using BC.Domain.Core;
using BC.Domain.Interfaces;

namespace BC.Infrastructure.Data.Repository
{
    public class ProjectRepository : GenericRepository<BcContext, Project>,  IProjectRepository
    {
        private readonly BcContext _context;

        public ProjectRepository(BcContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
