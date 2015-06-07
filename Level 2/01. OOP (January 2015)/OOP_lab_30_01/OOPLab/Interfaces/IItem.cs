namespace MultimediaShop.Interfaces
{
    using System.Collections.Generic;

    interface IItem
    {
        string Id { get; set; }

        string Title { get; }

        decimal Price { get; }

        List<string> Genres { get; }
    }
}