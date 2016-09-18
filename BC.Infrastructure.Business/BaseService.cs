using BC.Domain.Interfaces;
using BC.Infrastructure.Data.Repository;

namespace BC.Infrastructure.Business
{
    public abstract class BaseService
    {
        private static IUow _uow;

        protected BaseService()
        {
            //_uow = new Uow();
        }

        public static Uow GetUow()
        {
            _uow = _uow ?? new Uow();

            return _uow as Uow;
        }
    }
}
