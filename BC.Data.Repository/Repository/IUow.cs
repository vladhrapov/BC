using System;

namespace BC.Data.Repository.Repository
{
    public interface IUow : IDisposable
    {
        IUserRepository User { get; set; }
        IPaymentRepository Payment { get; set; }
        IProjectRepository Project { get; set; }
        void Save();
    }
}
