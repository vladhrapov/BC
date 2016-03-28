using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BC.Data.Entity;
using BC.Services;

namespace BC.Rest.Controllers
{
    public class ProjectController : ApiController
    {
        [HttpGet]
        public List<Project> Get()
        {
            return new ProjectService().GetProjects().ToList();
        }

        [HttpGet]
        public Project Get(Guid id)
        {
            return new ProjectService().GetprojectById(id);
        }

        [HttpPost]
        public void Add(Project project)
        {
            new ProjectService().AddOrUpdateProject(project);
        }

        [HttpPut]
        public void Update(Project project)
        {
            new ProjectService().AddOrUpdateProject(project);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            new ProjectService().DeleteProject(id);
        }
    }
}
