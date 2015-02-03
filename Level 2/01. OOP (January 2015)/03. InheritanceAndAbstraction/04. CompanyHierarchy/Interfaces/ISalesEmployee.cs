namespace Company.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ISalesEmployee
    {
        ISet<Sale> Sales { get; set; }

        void AddSales(ISet<Sale> sales);

        string ToString();
    }
}