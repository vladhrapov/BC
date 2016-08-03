using BC.Domain.Core;
using BC.Infrastructure.Business.BusinessServices;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BC.Web.Rest.Controllers
{
    public class PaymentController : ApiController
    {
        // GET: api/Payment
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new PaymentService().All().ToList());
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/Payment/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                var payment = new PaymentService().FindBy(p => p.Id == id);
                if (payment != null)
                {
                    return Ok(payment);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(string login, string password)
        {
            try
            {
                var payment = new PaymentService().FindBy(p => p.Login.Equals(login) && p.Password.Equals(password));

                if (payment != null)
                {
                    return Ok(payment);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // POST: api/Payment
        [HttpPost]
        public IHttpActionResult Add(Payment payment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new PaymentService().Add(payment);
                    return StatusCode(HttpStatusCode.Created);
                }
                catch (Exception)
                {
                    return InternalServerError();
                }
            }
            return BadRequest();
        }

        // PUT: api/Payment/5
        [HttpPut]
        public IHttpActionResult Update(Payment payment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new PaymentService().Update(payment);
                    return Ok();
                }
                catch (Exception)
                {
                    return InternalServerError();
                }
            }
            return BadRequest();
        }

        // DELETE: api/Payment/5
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                new PaymentService().Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
