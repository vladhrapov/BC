using BC.Domain.Core;
using BC.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using BC.Infastructure.Interfaces;

namespace BC.Infrastructure.Business.BusinessServices
{
    public class ProjectService : BaseService, IService<Project>
    {
        private readonly Uow _uow;

        public ProjectService()
        {
            this._uow = BaseService.GetUow();
        }

        public IEnumerable<Project> GetAll()
        {
            return _uow.Project.All.AsEnumerable();
        }

        public Project GetById(Guid id)
        {
            return _uow.Project.Find(id);
        }

        public void Add(Project project)
        {
            project.Id = CheckDefaultId(project);

            if (project.Name == string.Empty)
            {
                throw new ArgumentException("Project name cant be empty");
            }
            _uow.Project.InsertOrUpdate(project);
            _uow.Save();
        }

        public void Update(Project project)
        {
            project.Id = CheckDefaultId(project);

            if (project.Name == string.Empty)
            {
                throw new ArgumentException("Project name cant be empty");
            }
            _uow.Project.InsertOrUpdate(project);
            _uow.Save();
        }

        public void Delete(Guid id)
        {
            _uow.Project.Delete(id);
            _uow.Save();
        }

        private Guid CheckDefaultId(Project project)
        {
            return project.Id == default(Guid) ? Guid.NewGuid() : project.Id;
        }
    }
}
