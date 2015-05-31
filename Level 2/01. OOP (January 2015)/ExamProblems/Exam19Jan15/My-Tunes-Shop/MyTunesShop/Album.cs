namespace MyTunesShop
{
    using System.Collections.Generic;

    public class Album : Media, IAlbum
    {
        public Album(string title, decimal price, IPerformer performer, string genre, int year) 
            : base(title, price)
        {
            this.Performer = performer;
            this.Genre = genre;
            this.Year = year;
            this.Songs = new List<ISong>();
        }

        public IPerformer Performer { get; private set; }

        public string Genre { get; private set; }

        public int Year { get; private set; }

        public IList<ISong> Songs { get; private set; }

        public void AddSong(ISong song)
        {
            this.Songs.Add(song);
        }
    }
}