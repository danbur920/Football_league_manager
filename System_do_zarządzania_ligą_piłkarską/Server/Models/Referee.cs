using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class Referee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string? Level { get; set; }
        public int TotalYellowCardsGiven { get; set; }
        public int TotalRedCardsGiven { get; set; }
        public int TotalRefereedMatches { get; set; }
        public int TotalPenaltiesAwarded { get; set; }
        public virtual ICollection<RefereeStat>  RefereeStats { get; set; } = new List<RefereeStat>();
        public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
