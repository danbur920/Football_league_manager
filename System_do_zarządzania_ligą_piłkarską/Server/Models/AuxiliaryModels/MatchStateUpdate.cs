using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Updates;

namespace System_do_zarządzania_ligą_piłkarską.Server.Models.AuxiliaryModels
{
    public class MatchStateUpdate
    {
        public List<FootballerStatUpdateMatchState> StartingFootballerStats { get; set; } = new List<FootballerStatUpdateMatchState>(); // w wyjściowej 11tce
        public LeagueSeasonUpdateMatchState? LeagueSeason { get; set; } = new LeagueSeasonUpdateMatchState();
        public MatchUpdateMatchState? Match { get; set; } = new MatchUpdateMatchState();
        public RefereeUpdateMatchState? Referee { get; set; } = new RefereeUpdateMatchState();
        public RefereeStatUpdateMatchState? RefereeStat { get; set; } = new RefereeStatUpdateMatchState();
        public TeamStatUpdateMatchState? HomeTeamStat { get; set; } = new TeamStatUpdateMatchState();
        public TeamStatUpdateMatchState? AwayTeamStat { get; set; } = new TeamStatUpdateMatchState();
    }
}
