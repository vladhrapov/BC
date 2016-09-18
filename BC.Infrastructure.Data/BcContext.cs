using System.Data.Entity;
using BC.Domain.Core;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BC.Infrastructure.Data
{
    public class BcContext : DbContext
    {
        public BcContext()
            : base("BCDatabase")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<IdentityRole> Roles { get; set; }
        public virtual DbSet<IdentityUserClaim> UserClaims { get; set; }
        public virtual DbSet<IdentityUserLogin> UserLogins { get; set; }
        public virtual DbSet<IdentityUserRole> UserRoles { get; set; }
    }
}
