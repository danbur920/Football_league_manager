using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Updates
{
    public class FootballerStatUpdateMatchState
    {
        public int Id { get; set; }
        public int StartingAppearances { get; set; }
        public int MatchesPlayed { get; set; }
    }
}
//public class MatchStateUpdate
//{
//    public List<FootballerStat>? StartingFootballerStats { get; set; } // w wyjściowej 11tce
//    public LeagueSeason? LeagueSeason { get; set; }
//    public Match? Match { get; set; }
//    public Referee? Referee { get; set; }
//    public RefereeStat? RefereeStat { get; set; }
//    public TeamStat? HomeTeamStat { get; set; }
//    public TeamStat? AwayTeamStat { get; set; }
//}