using System;
using System.Collections.Generic;
using System.Linq;
using BC.Data.Entity;
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

        public Project GetprojectById(Guid id)
        {
            return _uow.Project.Find(id);
        }

        public void AddOrUpdateProject(Project project)
        {
            if (project.Name == string.Empty)
            {
                throw new ArgumentException("Project name cant be empty");
            }
            _uow.Project.InsertOrUpdate(project);
            _uow.Save();
        }

        public void DeleteProject(Guid id)
        {
            _uow.Project.Delete(id);
            _uow.Save();
        }
    }
}
