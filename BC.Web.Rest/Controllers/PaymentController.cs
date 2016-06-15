using BC.Domain.Core;
using BC.Infrastructure.Business.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BC.Web.Rest.Controllers
{
    public class PaymentController : ApiController
    {
        // GET: api/Payment
        public List<Payment> Get()
        {
            return new PaymentService().GetAll().ToList();
        }

        // GET: api/Payment/5
        public Payment Get(Guid id)
        {
            return new PaymentService().GetById(id);
        }

        public Payment Get(string login, string password)
        {
            return new PaymentService().PaymentGetByCredentials(login, password);
        }

        // POST: api/Payment
        [HttpPost]
        public void Add(Payment payment)
        {
            new PaymentService().Add(payment);
        }

        // PUT: api/Payment/5
        [HttpPut]
        public void Update(Payment payment)
        {
            new PaymentService().Update(payment);
        }

        // DELETE: api/Payment/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            new PaymentService().Delete(id);
        }
    }
}
