namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class TweetViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public UserPreviewViewModel WallOwner { get; set; }

        public UserPreviewViewModel Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime PostedOn { get; set; }

        public int RepliesCount { get; set; }

        public int RetweetsCount { get; set; }

        public int FavoritesCount { get; set; }

//        public bool IsFavorited { get; set; }

        public IEnumerable<ReplyViewModel> Replies { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> Create
        {
            get
            {
                return p => new TweetViewModel
                {
                    Id = p.Id,
                    Content = p.Content,
                    Author = new UserPreviewViewModel
                    {
                        Username = p.Author.UserName,
                        Fullname = p.Author.Fullname
                    },
                    WallOwner = new UserPreviewViewModel
                    {
                        Username = p.WallOwner.UserName,
                        Fullname = p.Author.Fullname
                    },
                    PostedOn = p.PostedOn,
                    RepliesCount = p.Replies.Count,
                    FavoritesCount = p.Favorites.Count,
                    Replies = p.Replies
                        .OrderByDescending(r => r.PostedOn)
                        .Take(3)
                        .Select(r => new ReplyViewModel
                        {
                            Id = r.Id,
                            Content = r.Content,
                            Author = new UserPreviewViewModel
                            {
                                Username = r.Author.UserName,
                                Fullname =  r.Author.Fullname
                            },
                            PostedOn = r.PostedOn
                        })
                };
            }
        }
    }
}