namespace Restaurants.Services.Infrastructure
{
    public interface IUserProvider
    {
        bool IsAuthenticated { get; }

        string GetUserId();
    }
}