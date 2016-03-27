using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BC.Data.Entity;
using BC.Services;

namespace BC.Rest.Controllers
{
    public class ProjectController : ApiController
    {
        public List<Project> Projects()
        {
            return new ProjectService().GetProjects().ToList();
        }

        public Project Project(Guid id)
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
        public void Delete(Guid projectId)
        {
            new ProjectService().DeleteProject(projectId);
        }
    }
}
