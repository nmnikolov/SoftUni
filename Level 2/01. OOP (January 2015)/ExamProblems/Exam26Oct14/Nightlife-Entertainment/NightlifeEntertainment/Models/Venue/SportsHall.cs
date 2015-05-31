namespace NightlifeEntertainment.Models.Venue
{
    using System.Collections.Generic;
    using Venue = NightlifeEntertainment.Venue;

    public class SportsHall : Venue
    {
        public SportsHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Sport, PerformanceType.Concert })
        {
        }
    }
}