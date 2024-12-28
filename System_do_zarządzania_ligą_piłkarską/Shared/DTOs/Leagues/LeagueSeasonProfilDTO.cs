using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;

namespace System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues
{
    public class LeagueSeasonProfilDTO
    {
        public int Id { get; set; }
        public int LeagueInfoId { get; set; }
        public Season? Season { get; set; }
        public int MatchesPlayed { get; set; }
        public DateOnly? LeagueStartDate { get; set; }
        public DateOnly? LeagueEndDate { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public Level? Level { get; set; }
        public virtual ImageDTO Image { get; set; }
    }
}
