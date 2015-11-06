namespace SoftUni.Blog.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface IApplicationData
    {
        IRepository<User> Users { get; }

        IRepository<Town> Towns { get; }

        void SaveChanges();
    }
}
