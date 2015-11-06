namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Glimpse.Core.Extensions;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels;
    using Models.ViewModels;
    using Twitter.Models;

    public class TweetsController : BaseController
    {
        // GET: Tweets
        [Authorize]
        [HttpPost]
        public ActionResult AddTweet(AddTweetBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
//                this.TempData["error"] = this.ModelState.Values
//                                        .SelectMany(x => x.Errors)
//                                        .Select(x => x.ErrorMessage)
//                                        .AsEnumerable();

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }

            var tweet = new Tweet
            {
                Content = model.Content,
                AuthorId = userId,
                Author = user,
                WallOwnerId = userId,
                WallOwner = user,
                PostedOn = DateTime.Now
            };

            user.OwnTweets.Add(tweet);
            this.Data.SaveChanges();
//            this.TempData["success"] = new []{"Tweet added sucessfully"};

            var dbTweet =
                this.Data.Tweets.All().Where(t => t.Id == tweet.Id).Select(TweetViewModel.Create).AsEnumerable();

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/TweetViewModel", dbTweet);
            }

            return this.RedirectToAction("Index", "Users", routeValues: new {this.User.Identity.Name});
        }
    }
}