namespace MultimediaShop.Interfaces
{
    using System;
    using Models;

    interface ISale
    {
        Item Item { get; }

        DateTime SaleDate { get; }
    }
}