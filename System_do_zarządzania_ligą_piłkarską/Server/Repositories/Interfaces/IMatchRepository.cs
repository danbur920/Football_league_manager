using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Models.AuxiliaryModels;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task AddNewMatchToTheSeason(Match newMatch);
        Task<Match> GetMatch(int matchId);
        Task<List<Match>> GetMatchesFromSpecificSeasonForLeagueMaster(int leagueSeasonId);
        Task<Match> GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(int leagueSeasonId, int matchId);
        Task UpdateMatchInfo(Match editMatch);
        Task AddNewMatchEventToTheSeason(MatchEvent newMatchEvent);

        // Metody służące do zmian różnych statystyk po wystąpieniu zdarzenia meczowego:
        Task<MatchEventStatsUpdate> GetDataToUpdateAfterNewMatchEvent(MatchEvent newMatchEvent);

        Task UpdateStatsAfterGoal(MatchEvent newMatchEvent);
        Task UpdateStatsAfterOwnGoal(MatchEvent newMatchEvent);
        Task UpdateStatsAfterYellowCard(MatchEvent newMatchEvent);
        Task UpdateStatsAfterRedCard(MatchEvent newMatchEvent);
        Task UpdateStatsAfterPenalty(MatchEvent newMatchEvent);
        Task UpdateStatsAfterSubstitution(MatchEvent newMatchEvent);

    }
}
