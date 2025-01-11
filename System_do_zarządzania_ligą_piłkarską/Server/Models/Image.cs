using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; } 

        public int? FootballerId { get; set; }
        public virtual Footballer? Footballer { get; set; }

        public int? TeamId { get; set; }
        public virtual Team? Team { get; set; }

        public int? RefereeId { get; set; }
        public virtual Referee? Referee { get; set; }

        public int? LeagueId { get; set; }
        public virtual LeagueInfo? League { get; set; }

        public int? TrophyId { get; set; }
        public virtual Trophy? Trophy { get; set; }
    }
}
