namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserFullViewModel : UserPreviewViewModel
    {
        public string Id { get; set; }

        public int TweetsCount { get; set; }

        public int FollowingCount { get; set; }

        public int FollowersCount { get; set; }

        public int FavoritesCount { get; set; }

//        public IEnumerable<TweetViewModel> Tweets { get; set; }

        public static Expression<Func<ApplicationUser, UserFullViewModel>> Create
        {
            get
            {
                return u => new UserFullViewModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Fullname = u.Fullname,
                    TweetsCount = u.OwnTweets.Count,
                    FollowingCount = u.FollowingUsers.Count,
                    FollowersCount = u.Followers.Count,
                    FavoritesCount = u.FavoritesTweets.Count
//                    Tweets = u.OwnTweets.OrderByDescending(t => t.PostedOn).Select(t => new TweetViewModel
//                    {
//                        Id = t.Id,
//                        Content = t.Content,
//                        Author = new UserPreviewViewModel
//                        {
//                            Username = t.Author.UserName,
//                            Fullname = t.Author.Fullname
//                        },
//                        WallOwner = new UserPreviewViewModel
//                        {
//                            Username = t.WallOwner.UserName,
//                            Fullname = t.Author.Fullname
//                        },
//                        PostedOn = t.PostedOn,
//                        RepliesCount = t.Replies.Count,
//                        FavoritesCount = t.Favorites.Count,
//                        Replies = t.Replies
//                            .OrderByDescending(r => r.PostedOn)
//                            .Take(3)
//                            .Select(r => new ReplyViewModel
//                            {
//                                Id = r.Id,
//                                Content = r.Content,
//                                Author = new UserPreviewViewModel
//                                {
//                                    Username = r.Author.UserName,
//                                    Fullname = r.Author.Fullname
//                                },
//                                PostedOn = r.PostedOn
//                            })
//                    })
                };
            }
        }
    }
}