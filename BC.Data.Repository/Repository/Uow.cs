using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Data.Repository.Repository
{
    public class Uow : IUow
    {
        private readonly BcContext _context;
        public IUserRepository User { get; set; }
        public IPaymentRepository Payment { get; set; }
        public IProjectRepository Project { get; set; }

        public Uow()
        {
            this._context = new BcContext();
            this.User = new UserRepository(_context);
            this.Payment = new PaymentRepository(_context);
            this.Project = new ProjectRepository(_context);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
