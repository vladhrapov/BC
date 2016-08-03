using BC.Domain.Core;
using BC.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<Project> All()
        {
            return _uow.Project.All();
        }

        public Project FindBy(Expression<Func<Project, bool>> predicate)
        {
            return _uow.Project.FindBy(predicate);
        }

        public void Add(Project project)
        {
            project.Id = CheckDefaultId(project);

            if (string.IsNullOrWhiteSpace(project.Name))
            {
                throw new ArgumentException("Project name can't be empty");
            }
            _uow.Project.Add(project);
            _uow.Save();
        }

        public void Update(Project project)
        {
            project.Id = CheckDefaultId(project);

            if (project.Name == string.Empty)
            {
                throw new ArgumentException("Project name cant be empty");
            }
            _uow.Project.Edit(project);
            _uow.Save();
        }

        public void Delete(Guid id)
        {
            var project = _uow.Project.FindBy(p => p.Id == id);
            _uow.Project.Delete(project);
            _uow.Save();
        }

        private Guid CheckDefaultId(Project project)
        {
            return project.Id == default(Guid) ? Guid.NewGuid() : project.Id;
        }
    }
}
