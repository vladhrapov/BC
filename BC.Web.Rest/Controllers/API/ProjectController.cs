using BC.Domain.Core;
using BC.Infrastructure.Business.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BC.Web.Rest.Controllers
{
    public class ProjectController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new ProjectService().GetAll().ToList());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                var project = new ProjectService().GetById(id);
                if (project != null)
                {
                    return Ok(project);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Add(Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new ProjectService().Add(project);
                    return StatusCode(HttpStatusCode.Created);
                }
                catch (Exception)
                {
                    return InternalServerError();
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Update(Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new ProjectService().Update(project);
                    return Ok();
                }
                catch (Exception)
                {
                    return InternalServerError();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                new ProjectService().Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}