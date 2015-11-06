namespace Twitter.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class TwitterContext : IdentityDbContext<ApplicationUser>, ITwitterContext
    {
        public TwitterContext()
            : base("TwitterContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>());
        }
        
        public virtual IDbSet<Tweet> Tweets { get; set; }
        public virtual IDbSet<Reply> Replies { get; set; }
        public virtual IDbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowerId");
                    m.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FollowingUsers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowedUserId");
                    m.ToTable("UsersFollowedUsers");
                });

            modelBuilder.Entity<Tweet>()
                .HasRequired<ApplicationUser>(p => p.Author)
                .WithMany(a => a.OwnTweets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasRequired<ApplicationUser>(p => p.WallOwner)
                .WithMany(o => o.WallTweets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired<ApplicationUser>(p => p.Sender)
                .WithMany(a => a.SendedMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired<ApplicationUser>(p => p.Receiver)
                .WithMany(a => a.ReceivedMessages)
                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<Message>()
//                .HasRequired<ApplicationUser>(p => p.Receiver)
//                .WithMany(o => o.SendedMessages)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ApplicationUser>()
//                .HasMany(u => u.OwnTweets)
//                .WithRequired(p => p.Author)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ApplicationUser>()
//                .HasMany(u => u.OwnTweets)
//                .WithRequired(p => p.WallOwner)
//                .WillCascadeOnDelete(false);

//            modelBuilder.Entity<ApplicationUser>()
//                .HasMany(u => u.WallTweets)
//                .WithRequired(p => p.Author)
//                .WillCascadeOnDelete(false);
//
//            modelBuilder.Entity<ApplicationUser>()
//                .HasMany(u => u.WallTweets)
//                .WithRequired(p => p.WallOwner)
//                .WillCascadeOnDelete(false);
//
//            modelBuilder.Entity<ApplicationUser>()
//                .HasMany(u => u.SendedMessages)
//                .WithRequired(u => u.Sender)
//                .WillCascadeOnDelete(false);
//
//            modelBuilder.Entity<ApplicationUser>()
//                .HasMany(u => u.SendedMessages)
//                .WithRequired(u => u.Receiver)
//                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }
    }
}