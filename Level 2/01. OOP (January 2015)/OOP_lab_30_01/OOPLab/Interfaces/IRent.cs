namespace MultimediaShop.Interfaces
{
    using System;
    using Models;

    interface IRent
    {
        Item Item { get; }

        RentState RentState { get; }

        DateTime RentDate { get; }

        DateTime Deadline { get; }

        DateTime ReturnDate { get; }

        void ReturnItem();
    }
}