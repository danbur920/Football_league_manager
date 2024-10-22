using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class LeagueSeason
    {
        public int Id { get; set; }
        public int LeagueInfoId { get; set; }
        public Season? Season { get; set; }
        public int MatchesPlayed { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
        public virtual LeagueInfo LeagueInfo { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
        public virtual ICollection<RefereeStat> RefereeStats { get; set; } = new List<RefereeStat>();
        public virtual ICollection<TeamStat> TeamsStats { get; set; } = new List<TeamStat>();
        public virtual ICollection<FootballerStat> FootballersStats { get; set; } = new List<FootballerStat>();
    }

    public enum Season
    {
        _Brak,
        _2023,
        _2023_2024,
        _2024,
        _2024_2025,
        _2025,
        _2025_2026,
        _2026,
        _2026_2027,
        _2027,
        _2027_2028,
        _2028,
        _2028_2029,
        _2029,
        _2029_2030,
        _2030
    }
}
