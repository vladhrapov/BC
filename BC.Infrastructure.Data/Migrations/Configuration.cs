namespace BC.Infrastructure.Data.Migrations
{
    using Domain.Core;
    using Domain.Core.Enums;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BC.Infrastructure.Data.BcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BC.Infrastructure.Data.BcContext context)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BcContext>());

            context.Projects.Add(new Project
            {
                Id = Guid.NewGuid(),
                Name = "Детский дома",
                TotalSum = 10000,
                CurrentSum = 0,
                Description = "Помощь дет дома",
                Info = "Просто текст не ясно какой но очень длиный ",
                ProjectStatus = ProjectStatus.Open,

            });

            //Managers
            var userManager = new UserManager<User>(new UserStore<User>(new BcContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BcContext()));

            // Adding roles
            IdentityResult userRole = roleManager.Create(new IdentityRole("user"));
            IdentityResult adminRole = roleManager.Create(new IdentityRole("admin"));

            //List<IdentityRole> rolesCollection = roleManager.Roles.ToList();

            var admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                Email = "admin@mymail.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",
                JoinDate = DateTime.Now
            };

            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "SuperPowerUser",
                Email = "vlad.khrapov@mymail.com",
                EmailConfirmed = true,
                FirstName = "Vladyslav",
                LastName = "Khrapov",
                JoinDate = DateTime.Now
            };

            var user2 = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "markkoshkin",
                Email = "markkoshkin@mymail.com",
                EmailConfirmed = true,
                FirstName = "Mark",
                LastName = "Koshkin",
                JoinDate = DateTime.Now
            };

            userManager.Create(user, "MySuperP@ssword!");

            userManager.Create(user2, "HelloWorld@!");
            userManager.Create(admin, "@AdminAdmin");

            User appUser = userManager.FindById(user.Id);
            if (appUser != null)
            {
                userManager.AddToRole(appUser.Id, "user");
            }

            appUser = userManager.FindById(user2.Id);
            if (appUser != null)
            {
                userManager.AddToRole(appUser.Id, "user");
            }

            appUser = userManager.FindById(admin.Id);
            if (appUser != null)
            {
                userManager.AddToRole(appUser.Id, "admin");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
