namespace System_do_zarządzania_ligą_piłkarską.Server.Models
{
    public class LeagueInfo
    {
        public int Id { get; set; }
        public string? LeagueMasterPrimaryId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Level? Level { get; set; }
        public virtual ApplicationUser LeagueMasterPrimary { get; set; }
        public virtual ICollection<LeagueSeason> LeagueSeasons { get; set; }
    }

    public enum Level
    {
        Brak,
        Lokalna,
        Okręgowa,
        Regionalna,
        Krajowa,
        Kontynentalna,
        Międzykontynentalna
    }
}
