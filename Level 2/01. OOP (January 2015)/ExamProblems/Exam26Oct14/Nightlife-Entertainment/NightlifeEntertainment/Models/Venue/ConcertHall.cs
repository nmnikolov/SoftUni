namespace NightlifeEntertainment.Models.Venue
{
    using System.Collections.Generic;
    using Venue = NightlifeEntertainment.Venue;

    public class ConcertHall : Venue
    {
        public ConcertHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre, PerformanceType.Concert })
        {
        }
    }
}