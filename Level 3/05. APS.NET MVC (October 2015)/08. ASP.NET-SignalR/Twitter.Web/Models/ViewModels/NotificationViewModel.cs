namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class NotificationViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

        public DateTime Date { get; set; }

        public static Expression<Func<Notification, NotificationViewModel>> Create
        {
            get
            {
                return n => new NotificationViewModel
                {
                    Id = n.Id,
                    Message = n.Message,
                    IsRead = n.IsRead,
                    Date = n.Date
                };
            }
        }
    }
}