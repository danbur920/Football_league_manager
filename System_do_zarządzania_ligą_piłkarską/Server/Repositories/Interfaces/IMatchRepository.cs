using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Models.AuxiliaryModels;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task AddNewMatchToTheSeason(Match newMatch);
        Task<Match> GetMatch(int matchId);
        Task UpdateMatch(Match match);
        Task<List<Match>> GetMatchesFromSpecificSeasonForLeagueMaster(int leagueSeasonId);
        Task<Match> GetExtensiveMatchInfo(int matchId);
        Task UpdateMatchInfo(Match editMatch);
        Task AddNewMatchEventToTheSeason(MatchEvent newMatchEvent);

        // Metody służące do zmian różnych statystyk po wystąpieniu zdarzenia meczowego:
        Task<MatchEventStatsUpdate> GetDataToUpdateAfterNewMatchEvent(MatchEvent newMatchEvent);

        Task UpdateStatsAfterGoal(MatchEventStatsUpdate statsUpdate);
        Task UpdateStatsAfterOwnGoal(MatchEventStatsUpdate statsUpdate);
        Task UpdateStatsAfterCard(MatchEventStatsUpdate statsUpdate);
        Task UpdateStatsAfterPenalty(MatchEventStatsUpdate statsUpdate);
        Task UpdateStatsAfterSubstitution(MatchEventStatsUpdate statsUpdate);
        Task UpdateStatsAfterMissedPenalty(MatchEventStatsUpdate statsUpdate);
        // ----------------------------------------------------------------

        // metody do zmian statystyk po zatwierdzeniu/anulowaniu meczu:
        Task<MatchStateUpdate> GetDataToUpdateAfterChangeMatchState(Match match);
        Task UpdateAfterChangeMatchState(MatchStateUpdate matchStateUpdate);
        // -----------------------------------------------------------------

        Task<MatchEvent> GetMatchEvent(int matchEventId);
        Task<List<MatchFootballer>> GetLineup(int matchId, int teamId);
        Task DeleteMatchEvent(MatchEvent matchEventToDelete);
        Task AddNewMatchFootballer(MatchFootballer newMatchFootballer);
        Task DeleteMatchFootballer(int matchFootballerId);
    }
}
