using BC.Domain.Interfaces;
using BC.Infrastructure.Data.Repository;

namespace BC.Infrastructure.Business
{
    public abstract class BaseService
    {
        private static IUow _uow;

        protected BaseService()
        {
            _uow = new Uow();
        }

        protected static Uow GetUow()
        {
            return _uow as Uow;
        }
    }
}
