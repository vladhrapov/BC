using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BC.Data.Entity;
using BC.Services;

namespace BC.Rest.Controllers
{
    public class PaymentController : ApiController
    {
        // GET: api/Payment
        public List<Payment> Get()
        {
            return new PaymentService().GetPayments().ToList();
        }

        // GET: api/Payment/5
        public Payment Get(Guid id)
        {
            return new PaymentService().GetPaymentById(id);
        }

        public Payment Get(string login, string password)
        {
            return new PaymentService().PaymentGetByCredentials(login , password);
        }

        // POST: api/Payment
        [HttpPost]
        public void Add(Payment payment)
        {
             new PaymentService().AddPayment(payment);
        }
        
        // PUT: api/Payment/5
        [HttpPut]
        public void Update(Payment payment)
        {
            new PaymentService().UpdatePayment(payment);
        }

        // DELETE: api/Payment/5
        [HttpDelete]
        public void Delete(Guid id)
        {
            new PaymentService().DeletePayment(id);
        }
    }
}
