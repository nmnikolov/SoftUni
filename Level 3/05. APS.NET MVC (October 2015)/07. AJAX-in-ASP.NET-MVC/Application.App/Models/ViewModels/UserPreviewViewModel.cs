namespace SoftUni.Blog.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Blog.Models;

    public class UserPreviewViewModel
    {
        public string UserName { get; set; }

        public string Fullname { get; set; }

        public static Expression<Func<User, UserPreviewViewModel>> Create
        {
            get
            {
                return u => new UserPreviewViewModel
                {
                    UserName = u.UserName,
                    Fullname = u.Fullname
                };
            }
        }
    }
}