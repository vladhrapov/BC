using System;
using System.Linq;
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
            get { return _context.Payments.AsQueryable(); }
        }

        public Payment Find(int id)
        {
            return _context.Payments.Find(id);
        }

        public void InsertOrUpdate(Payment payment)
        {
            if (payment != null)
            {
                if (payment.Id == default(int))
                {
                    _context.Payments.Add(payment);
                }
                else
                {
                    _context.Entry(payment).State = System.Data.Entity.EntityState.Modified;
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

            if (payment != null)
            {
                _context.Payments.Remove(payment);
            }
            else
            {
                throw new NullReferenceException("There is no such payment");
            }

        }

    }
}
