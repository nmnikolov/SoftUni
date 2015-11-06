namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using BindingModels;
    using Twitter.Models;

    public class EditProfileViewModel : EditProfileBindingModel
    {
        public static Expression<Func<ApplicationUser, EditProfileViewModel>> Create
        {
            get
            {
                return u => new EditProfileViewModel
                {
                    Username = u.UserName,
                    Email = u.Email,
                    Fullname = u.Fullname
                };
            }
        }
    }
}