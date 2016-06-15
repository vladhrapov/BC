using System;
using BC.Domain.Core;

namespace BC.Domain.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment GetByCredentials(string login, string password);
        Payment GetByCredentials(Func<Payment, bool> expression);
    }
}
