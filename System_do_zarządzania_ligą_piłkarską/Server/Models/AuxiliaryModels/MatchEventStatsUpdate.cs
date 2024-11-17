namespace System_do_zarządzania_ligą_piłkarską.Server.Models.AuxiliaryModels
{
    public class MatchEventStatsUpdate
    {
        public FootballerStat? PrimaryFootballerStat {  get; set; }
        public FootballerStat? SecondaryFootballerStat { get; set; }
        
        public TeamStat? HomeTeamStat { get; set; }
        public TeamStat? AwayTeamStat { get; set; }

        public LeagueSeason? LeagueSeason { get; set; }
        public Match? Match { get; set; }
        public Referee? Referee { get; set; }
        public RefereeStat? RefereeStat { get; set; }
    }
}
