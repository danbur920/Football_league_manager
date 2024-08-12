using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? CoachId { get; set; } // odnosi się do trenera - na potrzeby lepszego nazewnictwa użyłem CoachId zamiast UserId
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public int YearOfFoundation { get; set; }
        public virtual ApplicationUser? Coach { get; set; }
        public virtual ICollection<Match> HomeMatches { get; set; } = new List<Match>();
        public virtual ICollection<Match> AwayMatches { get; set; } = new List<Match>();
        public virtual ICollection<TeamStat> TeamStats { get; set; } = new List<TeamStat>();
        public virtual ICollection<Trophy> Trophies { get; set; } = new List<Trophy>();
        //public virtual ICollection<Footballer> Footballers { get; set; } = new List<Footballer>();
    }
}
