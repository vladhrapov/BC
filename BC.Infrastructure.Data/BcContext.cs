using System.Data.Entity;
using BC.Domain.Core;

namespace BC.Infrastructure.Data
{
    public class BcContext : DbContext
    {
        public BcContext()
            : base("BCDatabase")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
