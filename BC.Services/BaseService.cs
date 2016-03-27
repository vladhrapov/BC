using BC.Data.Repository;

namespace BC.Services
{
    public class BaseService
    {
        private static BcContext _context;

        protected BaseService()
        {

        }

        protected static BcContext GetContext()
        {
            return _context ?? (_context = new BcContext());
        }
    }
}
