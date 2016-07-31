using System;
using System.Linq;
using BC.Domain.Interfaces;
using BC.Domain.Core;

namespace BC.Infrastructure.Data.Repository
{
    public class PaymentRepository : GenericRepository<Payment> , IPaymentRepository
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

        public Payment Find(Guid id)
        {
            return _context.Payments.Find(id);
        }

        public void InsertOrUpdate(Payment payment)
        {
            if (payment != null)
            {
                if (All.FirstOrDefault(p => p.Id == payment.Id) == null)
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

        public void Delete(Guid id)
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

        public Payment GetByCredentials(string login, string password)
        {
            return _context.Payments.SingleOrDefault(p => p.Password.Equals(password) && p.Login.Equals(login));
        }

        public Payment GetByCredentials(Func<Payment, bool> expression)
        {
            return _context.Payments.SingleOrDefault(expression);
        }
    }
}
