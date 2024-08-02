using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class Referee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string? Level { get; set; }
        public virtual ICollection<RefereeStatDTO> RefereeStats { get; set; } = new List<RefereeStatDTO>();
        public virtual ICollection<MatchDTO> Matches { get; set; } = new List<MatchDTO>();
    }
}
