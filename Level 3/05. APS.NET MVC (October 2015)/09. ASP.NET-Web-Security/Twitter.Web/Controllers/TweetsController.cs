namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Hubs;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.SignalR;
    using Models.BindingModels;
    using Models.ViewModels;
    using Twitter.Models;

    public class TweetsController : BaseController
    {
        // GET: Tweets
        [System.Web.Mvc.Authorize]
        [HttpPost]
        public ActionResult AddTweet(AddTweetBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
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

            var dbTweet = this.Data.Tweets.All()
                .Where(t => t.Id == tweet.Id)
                .Select(TweetViewModel.Create)
                .AsEnumerable();

            this.SendTweet(tweet.Id);

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/TweetViewModel", dbTweet);
            }
            
            return this.RedirectToAction("Index", "Users", routeValues: new {this.User.Identity.Name});
        }

        [HttpGet]
        public ActionResult Tweet(int tweetId)
        {
            var tweet = this.Data.Tweets.All().Where(t => t.Id == tweetId).Select(TweetViewModel.Create).AsEnumerable();

            return this.PartialView("DisplayTemplates/TweetViewModel", tweet);
        }

        private void SendTweet(int tweetId)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TweetsHub>();
            hubContext.Clients.All.receiveTweet(tweetId);
        }
    }
}