namespace IdentityApp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityAppContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(IdentityAppContext context)
        {
            this.SeedUsersAndRoles(new []{"Administrator", "Member"});
        }

        private void SeedUsersAndRoles(string[] roleNames)
        {
            using (var context = new IdentityAppContext())
            {
                foreach (var roleName in roleNames)
                {
                    if (!context.Roles.Any(r => r.Name == roleName))
                    {
                        var roleStore = new RoleStore<IdentityRole>(context);
                        var roleManager = new RoleManager<IdentityRole>(roleStore);

                        roleManager.Create(new IdentityRole { Name = roleName });
                    }
                }

                if (!context.Users.Any(u => u.UserName == "admin"))
                {
                    var userStore = new UserStore<User>(context);
                    var userManager = new UserManager<User>(userStore);

                    var user = new User { UserName = "admin", Email = "admin@admin.com", Fullname = "Administrator" };
                    userManager.Create(user, "administrator");
                    userManager.AddToRole(user.Id, roleNames[0]);
                }
            }
        }
    }
}
