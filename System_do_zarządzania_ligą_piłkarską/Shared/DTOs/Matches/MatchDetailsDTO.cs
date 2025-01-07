using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches
{
    public class MatchDetailsDTO
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int Round { get; set; }
        public string? FootballStadium { get; set; } 
        public int? GoalsHome { get; set; }
        public int? GoalsAway { get; set; }
        public bool IsFinished { get; set; }
        public int HomeTeamSubstitutions { get; set; }
        public int AwayTeamSubstitutions { get; set; }
        public int HomeTeamYellowCards { get; set; }
        public int AwayTeamYellowCards { get; set; }
        public int HomeTeamRedCards { get; set; }
        public int AwayTeamRedCards { get; set; }
        public DateOnly? MatchDate { get; set; }
        public TimeOnly? MatchTime { get; set; }
        public virtual ShortRefereeInfoDTO? Referee { get; set; }
        public virtual TeamDTO? HomeTeam { get; set; }
        public virtual TeamDTO? AwayTeam { get; set; }
        public virtual ICollection<MatchEventDTO>? MatchEvents { get; set; }
    }
}
