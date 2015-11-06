namespace SoftUni.Blog.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Blog.Models;

    public class UserViewModel
    {
        public string Addreess { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public Status Status { get; set; }

        public int Age { get; set; }

        public string ProfileImage { get; set; }

        public static Expression<Func<User, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel
                {
                    Addreess = u.Address,
                    Contact = u.Contact,
                    Email = u.Email,
                    Status = u.Status,
                    Age = u.Age,
                    ProfileImage = u.ProfileImage
                };
            }
        }
    }
}