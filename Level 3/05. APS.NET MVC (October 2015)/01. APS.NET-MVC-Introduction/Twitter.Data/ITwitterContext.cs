namespace Twitter.Data
{
    using System;

    public interface ITwitterContext : IDisposable
    {
        int SaveChanges();
    }
}