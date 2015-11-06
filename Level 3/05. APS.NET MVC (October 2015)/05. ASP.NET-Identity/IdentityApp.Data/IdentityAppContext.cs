namespace IdentityApp.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class IdentityAppContext : IdentityDbContext<User>, IIdentityAppContext
    {
        public IdentityAppContext()
            : base("name=IdentityAppContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<IdentityAppContext, Configuration>());
        }

        public static IdentityAppContext Create()
        {
            return new IdentityAppContext();
        }
    }
}