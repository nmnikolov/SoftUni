namespace IdentityApp.Data.Contracts
{
    using Models;

    public interface IIdentityAppData
    {
        IRepository<User> Users { get; }

        int SaveChanges();
    }
}