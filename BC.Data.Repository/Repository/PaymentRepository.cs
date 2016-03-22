using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Data.Entity;

namespace BC.Data.Repository.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BcContext _context;

        public PaymentRepository(BcContext context)
        {
            this._context = context;
        }

        public IQueryable<Payment> All
        {
            get { return this._context.Payments.AsQueryable(); }
        }

        public Payment Find(int id)
        {
            return this._context.Payments.Find(id);
        }

        public void InsertOrUpdate(Payment payment)
        {
            if (payment != null)
            {
                if (payment.Id == default(Guid))
                {
                    this._context.Payments.Add(payment);
                }
                else
                {
                    this._context.Entry(payment).State = System.Data.Entity.EntityState.Modified;
                }
            }
            else
            {
                throw new NullReferenceException("Payment is null");
            }
        }

        public void Delete(int id)
        {
            var payment = this.Find(id);
            this._context.Payments.Remove(payment);
        }

    }
}
