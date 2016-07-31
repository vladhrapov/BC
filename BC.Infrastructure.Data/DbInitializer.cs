using System.Data.Entity;

namespace BC.Infrastructure.Data
{
    class DbInitializer : IDatabaseInitializer<BcContext>
    {
        public void InitializeDatabase(BcContext context)
        {
            //context.Users.Add(new User
            //{
            //    Id = Guid.NewGuid(),
            //    Login = "admin",
            //    Password = "qwerty",
            //    UserType = UserType.Admin
            //});

            //context.SaveChanges();

            //});

            //});
            //if (context.Database.Exists())
            //{
            //    context.Database.Delete();
            //}
        }
    }
}
