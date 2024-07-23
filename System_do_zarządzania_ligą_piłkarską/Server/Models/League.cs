using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string? Level { get; set; }
        public string? Season { get; set; }
        public int MatchesPlayed { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
        public virtual ICollection<RefereeStat> RefereeStats { get; set; } = new List<RefereeStat>();
        public virtual ICollection<TeamStat> TeamsStats { get; set; } = new List<TeamStat>();
        public virtual ICollection<FootballerStat> FootballersStats { get; set; } = new List<FootballerStat>();
    }
}
