using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DatabaseInitializer
{
    public class UserInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            IList<User> Users = new List<User>();

            Users.Add(new User() { Name = "UserName", Surename = "UserSurename", PersonalId = "1" });
            Users.Add(new User() { Name = "UserName1", Surename = "UserSurename1", PersonalId = "2" });
            Users.Add(new User() { Name = "UserName2", Surename = "UserSurename2", PersonalId = "3" });

            context.Users.AddRange(Users);

            base.Seed(context);
        }
    }
}
