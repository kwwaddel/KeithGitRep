namespace NewsAggregator.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsAggregator.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NewsAggregator.Data.ApplicationDbContext context)
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            var user = userManager.FindByName("user@gmail.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com"
                };
                userManager.Create(user, "password");
                user = userManager.FindByName("user@gmail.com");
            }
        }
    }
}
