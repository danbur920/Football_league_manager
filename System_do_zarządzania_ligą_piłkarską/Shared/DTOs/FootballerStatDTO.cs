using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.Models
{
    public class FootballerStatDTO
    {
        public int Id { get; set; }
        public int FootballerId { get; set; }
        public int LeagueId { get; set; }
        public int MatchesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public virtual FootballerDTO? Footballer { get; set; }
        public virtual LeagueDTO? League { get; set; }
    }
}
