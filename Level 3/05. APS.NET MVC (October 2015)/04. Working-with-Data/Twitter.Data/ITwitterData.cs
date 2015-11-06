namespace Twitter.Data
{
    using Models;
    using Repositories;

    public interface ITwitterData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Tweet> Tweets { get; }
        IRepository<TweetFavorite> TweetFavorites { get; }
        IRepository<Reply> Replies { get; }
        IRepository<Message> Messages { get; }

        int SaveChanges();
    }
}