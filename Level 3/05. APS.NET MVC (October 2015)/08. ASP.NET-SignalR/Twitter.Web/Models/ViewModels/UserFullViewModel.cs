namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;

    public class UserFullViewModel : UserPreviewViewModel
    {
        public int TweetsCount { get; set; }

        public int FollowingCount { get; set; }

        public int FollowersCount { get; set; }

        public int FavoritesCount { get; set; }
        
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
                };
            }
        }
    }
}