namespace SoftUni.Blog.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SoftUni.Blog.Models;
    using System.Data.Entity;

    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext()
            : base("ApplicationConnection", throwIfV1Schema: false)
        {

        }

        public virtual IDbSet<Town> Towns { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
