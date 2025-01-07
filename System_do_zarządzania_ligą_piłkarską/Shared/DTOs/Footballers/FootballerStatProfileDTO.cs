using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers
{
    public class FootballerStatProfileDTO
    {
        public int MatchesPlayed { get; set; }
        public int StartingAppearances { get; set; }
        public int SubstituteAppearances { get; set; }
        public int Goals { get; set; }
        public int OwnGoals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public LeagueSeasonDateDTO? LeagueSeason { get; set; }
    }
}
