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
