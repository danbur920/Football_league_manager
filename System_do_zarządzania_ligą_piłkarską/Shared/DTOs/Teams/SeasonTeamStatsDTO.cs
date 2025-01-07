using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams
{
    public class SeasonTeamStatsDTO
    {
        public int Id { get; set; }
        public int LeagueInfoId { get; set; }
        public Season? Season { get; set; }
        public int MatchesPlayed { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
        public ShortLeagueInfoDTO? LeagueInfo { get; set; }
        public List<TeamStatInfoDTO>? TeamsStats { get; set; } 
    }
}
