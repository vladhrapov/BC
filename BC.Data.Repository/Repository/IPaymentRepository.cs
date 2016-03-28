using System;
using BC.Data.Entity;

namespace BC.Data.Repository.Repository
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment GetByCredentials(string login, string password);
        Payment GetByCredentials(Func<Payment, bool> expression);
    }
}
