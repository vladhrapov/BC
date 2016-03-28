using BC.Data.Repository;
using BC.Data.Repository.Repository;

namespace BC.Services
{
    public class BaseService
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
