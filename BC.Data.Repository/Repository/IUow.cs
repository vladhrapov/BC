using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
