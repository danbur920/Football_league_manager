using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class LeagueSeason
    {
        public int Id { get; set; }
        public int LeagueInfoId { get; set; }
        public string? LeagueMasterSecondaryId {  get; set; } // drugorzędny zarządca ligi - zarządza danym sezonem, ale nie całą ligą
        public Season? Season { get; set; }
        public int MatchesPlayed { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
        public virtual LeagueInfo LeagueInfo { get; set; }
        public virtual ApplicationUser LeagueMasterSecondary { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
        public virtual ICollection<RefereeStat> RefereeStats { get; set; } = new List<RefereeStat>();
        public virtual ICollection<TeamStat> TeamsStats { get; set; } = new List<TeamStat>();
        public virtual ICollection<FootballerStat> FootballersStats { get; set; } = new List<FootballerStat>();
    }
}
