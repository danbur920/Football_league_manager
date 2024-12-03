using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Updates
{
    public class TeamStatUpdateMatchState
    {
        public int Id { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int Points { get; set; }
    }
}
