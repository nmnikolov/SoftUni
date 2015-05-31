namespace NightlifeEntertainment
{
    using System;
    using System.Linq;
    using System.Text;
    using Models.Performance;
    using Models.Tickets;
    using Models.Venue;

    public class CinemaEngineExtension : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new Opera(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            IVenue venue;

            switch (commandWords[2])
            {
                case "theatre":
                    venue = this.GetVenue(commandWords[5]);
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    venue = this.GetVenue(commandWords[5]);
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[3]);

            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }

                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var ticketsSold = performance.Tickets.Count(t => t.Status == TicketStatus.Sold);
            var totalPrice = performance.Tickets.Where(t => t.Status == TicketStatus.Sold).Sum(t => t.Price);
            
            StringBuilder report = new StringBuilder();
            report.AppendLine(string.Format("{0}: {1} ticket(s), total: ${2:F2}", performance.Name, ticketsSold, totalPrice));
            report.AppendLine(string.Format("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location));
            report.AppendLine(string.Format("Start time: {0}", performance.StartTime));

            this.Output.Append(report);
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            var startTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            var performances = this.Performances.Where(p => p.Name.IndexOf(commandWords[1], StringComparison.OrdinalIgnoreCase) >= 0 &&
                p.StartTime >= startTime).ToList();
            var venues = this.Venues.Where(v => v.Name.IndexOf(commandWords[1], StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            this.Output.AppendLine(string.Format("Search for \"{0}\"", commandWords[1]));

            this.Output.AppendLine("Performances:");
            if (performances.Any())
            {
                performances = performances.OrderBy(p => p.StartTime).ThenByDescending(p => p.BasePrice).ThenBy(p => p.Name).ToList();
                foreach (var performance in performances)
                {
                    this.Output.AppendLine('-' + performance.Name);
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }

            this.Output.AppendLine("Venues:");
            if (venues.Any())
            {
                venues = venues.OrderBy(v => v.Name).ToList();
                foreach (var venue in venues)
                {
                    this.Output.AppendLine('-' + venue.Name);
                    var venuePerformances = this.Performances.Where(p => p.Venue.Name == venue.Name && p.StartTime >= startTime).OrderBy(p => p.StartTime).ThenByDescending(p => p.BasePrice).ThenBy(p => p.Name).ToList();
                    foreach (var venuePerformance in venuePerformances)
                    {
                        this.Output.AppendLine("--" + venuePerformance.Name);
                    }
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }
    }
}