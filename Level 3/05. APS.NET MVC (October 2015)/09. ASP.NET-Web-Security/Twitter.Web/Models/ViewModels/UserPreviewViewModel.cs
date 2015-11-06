namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using Twitter.Models;

    public class UserPreviewViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Fullname { get; set; }

        public bool IsFollowed { get; set; }

        public static Expression<Func<ApplicationUser, UserPreviewViewModel>> Create
        {
            get
            {
                return u => new UserPreviewViewModel
                {
                    Id = u.Id,
                    Fullname = u.Fullname,
                    Username = u.UserName,
                    IsFollowed = u.Followers.Any(uu => uu.UserName == HttpContext.Current.User.Identity.Name)
                };
            }
        }
    }
}