using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Domain.Core;
using BC.Domain.Interfaces;

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
