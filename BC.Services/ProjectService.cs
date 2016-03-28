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
        private readonly Uow _uow;

        public ProjectService()
        {
            this._uow = BaseService.GetUow();
        }

        public IEnumerable<Project> GetProjects()
        {
            return _uow.Project.All.AsEnumerable();
        }

        public Project GetprojectById(int id)
        {
            return _uow.Project.Find(id);
        }

        public void AddOrUpdateProject(Project project)
        {
            if (project.Name == "")
            {
                throw new ArgumentException("Project name cant be empty");
            }
            _uow.Project.InsertOrUpdate(project);
            _uow.Save();
        }

        public void DeleteProject(int id)
        {
            _uow.Project.Delete(id);
            _uow.Save();
        }
    }
}
