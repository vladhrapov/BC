using System;
using System.Linq.Expressions;
using BC.Domain.Interfaces;

namespace BC.Infrastructure.Data.Repository
{
    public class Uow : IUow
    {
        private BcContext _context;
        public IUserRepository User { get; set; }
        public IPaymentRepository Payment { get; set; }
        public IProjectRepository Project { get; set; }

        public Uow()
        {
            this._context = this.GetContext();
            //this.User = new UserRepository(_context);
            this.Payment = new PaymentRepository(_context);
            this.Project = new ProjectRepository(_context);
        }

        public BcContext GetContext()
        {
            this._context = this._context ?? new BcContext();

            return this._context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
