namespace Company.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface ISale
    {
        string ProductName { get; set; }

        DateTime SaleDate { get; set; }

        decimal Price { get; set; }
    }
}