namespace Twitter.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models.BindingModels;
    using Models.ViewModels;
    using Twitter.Models;

    public class UsersController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
        }

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public ActionResult Index(string username, int pageNum = 0)
        {
            var user = this.Data.Users.All()
                .Where(u => u.UserName == username)
                .Select(UserFullViewModel.Create)
                .FirstOrDefault();

            if (user == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var tweets = this.GetRecordsForPage(user.Id, pageNum);

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/TweetViewModel", tweets);
            }

            var result = new UserWallViewModel
            {
                User = user, 
                Tweets = tweets
            };

            return View(result);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {
            var username = this.User.Identity.Name;
            var userData = this.Data.Users.All()
                .Where(u => u.UserName == username)
                .Select(EditProfileViewModel.Create)
                .FirstOrDefault();

            return View(userData);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditProfileBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
                user.Fullname = model.Fullname;
                user.Email = model.Email;

                var result = await this.UserManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await this.SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    this.TempData["Success"] = new[] {"Edit successfull"};
                }
                else
                {
                    this.AddErrors(result);
                }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Users()
        {
            var users = this.Data.Users.All()
                    .Where(u => u.UserName != this.User.Identity.Name)
                    .Select(UserPreviewViewModel.Create)
                    .AsEnumerable();

            return this.View(users);
        }

        [HttpPost]
        [Authorize]
        public ActionResult FollowUser(string userId)
        {
            var targetUser = this.Data.Users.Find(userId);
            if (targetUser == null || targetUser.Followers.Any(u => u.UserName == this.User.Identity.Name))
            {
                return this.HttpNotFound();
            }

            targetUser.Followers.Add(this.UserProfile);
            this.UserProfile.FollowingUsers.Add(targetUser);

            this.Data.SaveChanges();

            return this.Content(this.UserProfile.Fullname + " followed you.");
        }

        [HttpPost]
        [Authorize]
        public ActionResult UnfollowUser(string userId)
        {
            var targetUser = this.Data.Users.Find(userId);
            if (targetUser == null || targetUser.Followers.All(u => u.UserName != this.User.Identity.Name))
            {
                return this.HttpNotFound();
            }

            targetUser.Followers.Remove(this.UserProfile);
            this.UserProfile.FollowingUsers.Remove(targetUser);

            this.Data.SaveChanges();

            return this.Content("");
        }

        private IEnumerable<TweetViewModel> GetRecordsForPage(string userId, int pageNum)
        {
            IQueryable<Tweet> tweets =
                this.Data.Tweets.All()
                .Where(t => t.AuthorId == userId)
                .OrderByDescending(t => t.PostedOn);

            var result = tweets
                    .Skip(AppConfig.TweetsPerPage * pageNum)
                    .Take(AppConfig.TweetsPerPage)
                    .Select(TweetViewModel.Create)
                    .AsEnumerable();

            return result;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}