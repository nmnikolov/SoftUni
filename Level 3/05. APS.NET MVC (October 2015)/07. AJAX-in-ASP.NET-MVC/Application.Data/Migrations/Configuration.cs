namespace SoftUni.Blog.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using DAO;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Newtonsoft.Json;
    using System.Web;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        private string usersImportPath;
        private string townsImportPath;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "SoftUni.Blog.Data.ApplicationContext";
        }

        protected override void Seed(ApplicationContext context)
        {
            this.SeedAdminRole(context, "Admin");
            this.SeedUsers(context);
            this.SeedTowns(context);
        }

        private void SeedAdminRole(ApplicationContext context, string roleName)
        {
            //using (var context = new ApplicationContext())
            //{
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    roleManager.Create(new IdentityRole { Name = roleName });
                }
            //}
        }

        private void SeedUsers(ApplicationContext context)
        {
            //using (var context = new ApplicationContext())
            //{
                if (!context.Users.Any())
                {
                    this.usersImportPath = HttpContext.Current.Server.MapPath(@"~\") + @"Seed\users.json";

                    var json = File.ReadAllText(this.usersImportPath);

                    var users = JsonConvert.DeserializeObject<IList<UserModel>>(json);

                    var userStore = new UserStore<User>(context);
                    var userManager = new UserManager<User>(userStore);

                    foreach (var userModel in users)
                    {
                        var user = new User
                        {
                            UserName = userModel.UserName,
                            Email = userModel.Email,
                            Fullname = userModel.Fullname,
                            Address = userModel.Address,
                            Contact = userModel.Contact,
                            Status = userModel.Status,
                            Age = userModel.Age,
                            ProfileImage = userModel.ProfileImage
                        };

                        userManager.Create(user, userModel.Password);
                    }
                }
            //}
        }

        private void SeedTowns(ApplicationContext context)
        {
            if (!context.Towns.Any())
            {
                string line;

                this.townsImportPath = HttpContext.Current.Server.MapPath(@"~\") + @"Seed\towns.txt";

                StreamReader file = new StreamReader(this.townsImportPath);
                while ((line = file.ReadLine()) != null)
                {
                    var town = new Town
                    {
                        Name = line
                    };

                    context.Towns.Add(town);
                }
            }
        }
    }
}
