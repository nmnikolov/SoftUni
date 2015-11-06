namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Models.ViewModels;
    using Twitter.Models;

    public class NotificationsController : BaseController
    {
        [HttpPost]
        [Authorize]
        public ActionResult AddNotification(string userId, string message)
        {
            var targetUser = this.Data.Users.Find(userId);

            if (targetUser == null)
            {
                return this.HttpNotFound();
            }

            var notification = new Notification
            {
                Message = message,
                IsRead = false,
                Date = DateTime.Now
            };

            targetUser.Notifications.Add(notification);
            this.Data.SaveChanges();


            return this.Content("true");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var notifications = this.Data.Notifications.All()
                .Where(n => n.User.UserName == this.User.Identity.Name)
                .OrderByDescending(n => n.Date);

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
            }

            this.Data.SaveChanges();
            this.ViewBag.notifications = 0;

            return this.View(notifications.Select(NotificationViewModel.Create).AsEnumerable());
        }
    }
}