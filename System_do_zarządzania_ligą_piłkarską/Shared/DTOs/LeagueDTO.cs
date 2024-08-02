using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs
{
    public class LeagueDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string? Level { get; set; }
        public string? Season { get; set; }
        public int MatchesPlayed { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }
        public virtual ICollection<MatchDTO> Matches { get; set; } = new List<MatchDTO>();
        public virtual ICollection<RefereeStatDTO> RefereeStats { get; set; } = new List<RefereeStatDTO>();
        public virtual ICollection<TeamStatDTO> TeamsStats { get; set; } = new List<TeamStatDTO>();
        public virtual ICollection<FootballerStatDTO> FootballersStats { get; set; } = new List<FootballerStatDTO>();
    }
}
