using BC.Domain.Core;
using BC.Infrastructure.Business.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BC.Web.Rest.Controllers
{
    public class ProjectController : ApiController
    {
        [HttpGet]
        public List<Project> Get()
        {
            return new ProjectService().GetAll().ToList();
        }

        [HttpGet]
        public Project Get(Guid id)
        {
            return new ProjectService().GetById(id);
        }

        [HttpPost]
        public void Add(Project project)
        {
            new ProjectService().Add(project);
        }

        [HttpPut]
        public void Update(Project project)
        {
            new ProjectService().Update(project);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            new ProjectService().Delete(id);
        }
    }
}
