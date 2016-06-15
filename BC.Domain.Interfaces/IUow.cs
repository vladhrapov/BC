using System;

namespace BC.Domain.Interfaces
{
    public interface IUow : IDisposable
    {
        IUserRepository User { get; set; }
        IPaymentRepository Payment { get; set; }
        IProjectRepository Project { get; set; }
        void Save();
    }
}
