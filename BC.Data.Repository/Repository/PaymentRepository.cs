using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Data.Repository.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BcContext _context;

        public PaymentRepository(BcContext context)
        {
            this._context = context;
        }

        public IQueryable<Entity.Payment> All
        {
            get { throw new NotImplementedException(); }
        }

        public Entity.Payment Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Entity.Payment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
