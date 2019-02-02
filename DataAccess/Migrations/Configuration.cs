namespace DataAccess.Migrations
{
    using DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.DataContext context)
        {
            context.Users.AddOrUpdate(x=> x.Id,
                new User() { Name = "UserName", Surename = "UserSurename", PersonalId = "1" },
                new User() { Name = "UserName1", Surename = "UserSurename1", PersonalId = "2" },
                new User() { Name = "UserName2", Surename = "UserSurename2", PersonalId = "3" });
        }
    }
}
