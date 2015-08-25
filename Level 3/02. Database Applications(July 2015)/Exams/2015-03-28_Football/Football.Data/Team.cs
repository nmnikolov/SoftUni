//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Football.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public Team()
        {
            this.TeamMatchesAwayTeam = new HashSet<TeamMatch>();
            this.TeamMatchesHomeTeam = new HashSet<TeamMatch>();
            this.Leagues = new HashSet<League>();
        }
    
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string CountryCode { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ICollection<TeamMatch> TeamMatchesAwayTeam { get; set; }
        public virtual ICollection<TeamMatch> TeamMatchesHomeTeam { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
