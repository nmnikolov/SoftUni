namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class ReplyViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserPreviewViewModel Author { get; set; }

        public DateTime PostedOn { get; set; }

        public static Expression<Func<Reply, ReplyViewModel>> Create
        {
            get
            {
                return r => new ReplyViewModel
                {
                    Id = r.Id,
                    Content = r.Content,
                    Author = new UserPreviewViewModel
                    {
                        Username = r.Author.UserName
                    },
                    PostedOn = r.PostedOn
                };
            }
        }
    }
}