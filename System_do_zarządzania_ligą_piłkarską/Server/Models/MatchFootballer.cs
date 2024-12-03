namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class MatchFootballer
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int FootballerId { get; set; }
        public int TeamId { get; set; }
        public bool IsStartingPlayer { get; set; }
        public bool IsSubstitutePlayer { get; set; } // nieuzywane
        public virtual Footballer? Footballer { get; set; }
        public virtual Match? Match { get; set; }
        public virtual Team? Team { get; set; }
    }
}
