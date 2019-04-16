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
            context.Users.Add(new User() {
                 Name = "UserName",
                 Surename = "UserSurename",
                 Email = "Email",
                 Balance = 1000.00,
                 PersonalId = "AKCDRTE",
                 Login = "Login",
                 Password = "PAssword"
            });
        }
    }
}
