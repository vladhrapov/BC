using BC.Data.Repository;

namespace BC.Services
{
    public class BaseService
    {
        private static readonly BcContext _context;

        protected BaseService()
        {
           
        }

        protected static BcContext GetContext()
        {
            return _context ?? new BcContext();
        }
    }
}
