using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task AddNewMatchToTheSeason(Match newMatch);
        Task<List<Match>> GetMatchesFromSpecificSeasonForLeagueMaster(int leagueSeasonId);
        Task<Match> GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(int leagueSeasonId, int matchId);
    }
}
