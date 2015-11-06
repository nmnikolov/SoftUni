namespace IdentityApp.Data.Contracts
{
    using System;

    public interface IIdentityAppContext: IDisposable
    {
        int SaveChanges();
    }
}