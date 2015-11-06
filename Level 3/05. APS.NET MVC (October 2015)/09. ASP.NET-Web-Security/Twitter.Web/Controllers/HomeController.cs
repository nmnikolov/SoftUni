using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.Web.Controllers
{
    using Hubs;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.SignalR;
    using Models.ViewModels;
    using Twitter.Models;

    public class HomeController : BaseController
    {
        public ActionResult Index(int pageNum = 0)
        {
            this.ViewBag.IsEndOfRecords = false;

            var tweets = this.GetRecordsForPage(pageNum);


            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("DisplayTemplates/TweetViewModel", tweets);
            }
                
            return this.View("Index", tweets);
        }

        [HttpPost]
        public ActionResult SendNotification(string type, string notification)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TweetsHub>();
            hubContext.Clients.All.receiveNotification(type, notification);
            return this.Content("Notification sent.<br />");
        }

        private IEnumerable<TweetViewModel> GetRecordsForPage(int pageNum)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            IQueryable<Tweet> tweets = this.Data.Tweets.All();

            if (user != null)
            {
                tweets = tweets.Where(t => t.Author.Followers.Any(f => f.Id == userId));
            }

            tweets = tweets.OrderByDescending(o => o.PostedOn);

            var result = tweets
                    .Skip(AppConfig.TweetsPerPage * pageNum)
                    .Take(AppConfig.TweetsPerPage)
                    .Select(TweetViewModel.Create)
                    .AsEnumerable();

            return result;
        }
    }
}