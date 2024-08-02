using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string? CoachId { get; set; } // odnosi się do trenera - na potrzeby lepszego nazewnictwa użyłem CoachId zamiast UserId
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public int YearOfFoundation { get; set; }
        public virtual ApplicationUserDTO? Coach { get; set; }
        public virtual ICollection<MatchDTO> HomeMatches { get; set; } = new List<MatchDTO>();
        public virtual ICollection<MatchDTO> AwayMatches { get; set; } = new List<MatchDTO>();
        public virtual ICollection<TeamStatDTO> TeamStats { get; set; } = new List<TeamStatDTO>();
        public virtual ICollection<TrophyDTO> Trophies { get; set; } = new List<TrophyDTO>();
        public virtual ICollection<FootballerDTO> Footballers { get; set; } = new List<FootballerDTO>();
    }
}
