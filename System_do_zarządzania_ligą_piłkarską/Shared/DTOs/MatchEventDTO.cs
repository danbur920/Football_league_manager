using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class MatchEventDTO
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int? PrimaryFootballerId { get; set; } // strzelec gola (w tym również gol samobójczy),
                                                      // żółta/czerwona kartka,
                                                      // wykonawca rzutu karnego,
                                                      // zawodnik schodzący
        public int? SecondaryFootballerId { get; set; } // asystent gola,
                                                        // zawodnik wchodzący
        public int? Minute { get; set; }
        public EventType EventType { get; set; }
        public MatchDTO? Match { get; set; }
    }

    public enum EventType
    {
        Goal,
        OwnGoal,
        YellowCard,
        RedCard,
        Penalty,
        Substitution
    }
}

