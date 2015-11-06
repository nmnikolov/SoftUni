using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Twitter.Web.Controllers
{
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models.ViewModels;
    using Twitter.Models;

    public class InfiniteScrollDemoController : BaseController
    {
        public const int RecordsPerPage = 5;
        public InfiniteScrollDemoController()
        {
            this.ViewBag.RecordsPerPage = RecordsPerPage;
        }

        public ActionResult Index()
        {
            return this.RedirectToAction("GetCustomers");
        }

        public ActionResult GetCustomers(int? pageNum)
        {
            pageNum = pageNum ?? 0;
            this.ViewBag.IsEndOfRecords = false;
            
            if (this.Request.IsAjaxRequest())
            {
                var customers = this.GetRecordsForPage(pageNum.Value);
                this.ViewBag.IsEndOfRecords = (customers.Any()) && ((pageNum.Value * RecordsPerPage) >= customers.Last().Key);
                return this.PartialView("DisplayTemplates/TweetViewModel", customers);
            }

            else
            {
                this.ViewBag.Customers = this.GetRecordsForPage(pageNum.Value);
                return this.View("Index");
            }
        }

        public Dictionary<int, TweetViewModel> GetRecordsForPage(int pageNum)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.Find(userId);

            IQueryable<Tweet> tweets = this.Data.Tweets.All();

            if (user != null)
            {
                tweets = tweets.Where(t => t.Author.FollowingUsers.Any(f => f.Id == userId));
            }

            tweets = tweets.OrderByDescending(o => o.PostedOn);

            var result = tweets
                    .Skip(AppConfig.TweetsPerPage * pageNum)
                    .Take(AppConfig.TweetsPerPage)
                    .Select(TweetViewModel.Create)
                    .ToDictionary(x => x.Id, x => x);

            return result;
        }
    }
}