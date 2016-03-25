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
    }
}
