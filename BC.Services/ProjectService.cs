using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using BC.Data.Entity;
using BC.Data.Repository;
using BC.Data.Repository.Repository;

namespace BC.Services
{
    public class ProjectService : BaseService
    {
        private readonly IProjectRepository ProjectRepository;

        public int x = new Random().Next(0, 20000);

        public ProjectService()
        {
            ProjectRepository = new ProjectRepository(BaseService.GetContext());
        }

        public IEnumerable<Project> GetProjects()
        {
            return ProjectRepository.All;
        }

        public Project GetprojectById(Guid id)
        {
            var project = ProjectRepository.Find(id);
            //project.Payments = get payments 
            return project;
        }
    }
}
