namespace SoftUni.Blog.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Models.ViewModels;

    public class UsersController : BaseController
    {
        public UsersController(IApplicationData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var users = this.Data.Users.All().Select(UserPreviewViewModel.Create);
            return this.View(users);
        }

        [HttpGet]
        public bool UserNameChecker(string newUserName)
        {
            var exists = this.Data.Users.All().Any(u => u.UserName == newUserName);
            return exists;
        }

        [HttpGet]
        public bool EmailChecker(string newEmail)
        {
            var exists = this.Data.Users.All().Any(u => u.Email == newEmail);
            return exists;
        }

        [HttpGet]
        public ActionResult GetUserPreview(string username)
        {
            var user = this.Data.Users.All().Where(u => u.UserName == username).Select(UserViewModel.Create).FirstOrDefault();
            return this.PartialView("_Tooltip", user);
        } 
    }
}