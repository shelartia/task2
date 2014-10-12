namespace Task2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Task2.Models.UserInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Task2.Models.UserInfoContext context)
        {
            context.UserInfoes.AddOrUpdate(i => i.FirstName,
                new UserInfo
                {
                    FirstName = "Harry",
                    LastName = "Mally",
                    Address = "st.Baker"
                },
                new UserInfo
                {
                    FirstName = "Larry",
                    LastName = "Dolly",
                    Address = "st.Bakerfort"
                },
                new UserInfo
                {
                    FirstName = "Garry",
                    LastName = "Fally",
                    Address = "st.Bakerstreet"
                }
            );

        }
    }
}
