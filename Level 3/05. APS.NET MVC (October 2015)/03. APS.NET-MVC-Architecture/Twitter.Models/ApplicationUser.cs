namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Tweet> ownTweets;
        private ICollection<Tweet> wallTweets;
        private ICollection<ApplicationUser> followers;
        private ICollection<ApplicationUser> followingUsers;
        private ICollection<TweetFavorite> favoriteTweets;
        private ICollection<Message> sendedMessages; 
        private ICollection<Message> receivedMessages; 

        public ApplicationUser()
        {
            this.ownTweets = new HashSet<Tweet>();
            this.wallTweets = new HashSet<Tweet>();
            this.followers = new HashSet<ApplicationUser>();
            this.followingUsers = new HashSet<ApplicationUser>();
            this.favoriteTweets = new HashSet<TweetFavorite>();
            this.sendedMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
        }
        
        public string Fullname { get; set; }
        
        public virtual ICollection<Tweet> OwnTweets
        {
            get { return this.ownTweets; }
            set { this.ownTweets = value; }
        }

        public virtual ICollection<Tweet> WallTweets
        {
            get { return this.wallTweets; }
            set { this.wallTweets = value; }
        }

        public virtual ICollection<TweetFavorite> FavoritesTweets
        {
            get { return this.favoriteTweets; }
            set { this.favoriteTweets = value; }
        }

        public virtual ICollection<ApplicationUser> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<ApplicationUser> FollowingUsers
        {
            get { return this.followingUsers; }
            set { this.followingUsers = value; }
        }

        public virtual ICollection<Message> SendedMessages
        {
            get { return this.sendedMessages; }
            set { this.sendedMessages = value; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}