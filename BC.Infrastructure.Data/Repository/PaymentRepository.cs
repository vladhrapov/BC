using System;
using System.Linq;
using BC.Domain.Interfaces;
using BC.Domain.Core;

namespace BC.Infrastructure.Data.Repository
{
    public class PaymentRepository : GenericRepository<BcContext, Payment>, IPaymentRepository, IDisposable
    {
        private readonly BcContext _context;

        public PaymentRepository(BcContext context)
        {
            this._context = context;
        }
    }
}
