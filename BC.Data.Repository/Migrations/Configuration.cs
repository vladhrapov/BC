namespace BC.Data.Repository.Migrations
{
    using Entity;
    using Entity.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BC.Data.Repository.BcContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BC.Data.Repository.BcContext context)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BcContext>());

            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "admin",
                Password = "qwerty12345",
                UserType = UserType.Admin
            });

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
