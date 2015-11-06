namespace Twitter.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure;
    using Models.ViewModels;
    using Twitter.Models;

    public class UsersController : BaseController
    {
        // GET: Users
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

        public IEnumerable<TweetViewModel> GetRecordsForPage(string userId, int pageNum)
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
    }
}