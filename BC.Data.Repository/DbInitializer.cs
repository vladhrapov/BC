using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Data.Entity;

namespace BC.Data.Repository
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
