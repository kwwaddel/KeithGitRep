namespace SignalRAuth.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalRAuth.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SignalRAuth.Models.ApplicationDbContext context)
        {
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
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);


            // FindByName() extension requires Microsoft.AspNet.Identity
            var user = userManager.FindByName("kwwaddel@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "kwwaddel@gmail.com",
                    Email = "kwwaddel@gmail.com"
                };
                userManager.Create(user, "password");
                //userManager.AddClaim(user.Id, new Claim("EditProducts", "true"));
            }

            var user2 = userManager.FindByName("player2@gmail.com");
            if (user2 == null)
            {
                user2 = new ApplicationUser
                {
                    UserName = "player2@gmail.com",
                    Email = "player2@gmail.com"
                };
                userManager.Create(user2, "password");
                //userManager.AddClaim(user2.Id, new Claim("EditProducts", "true"));
            }
        }
    }
}
