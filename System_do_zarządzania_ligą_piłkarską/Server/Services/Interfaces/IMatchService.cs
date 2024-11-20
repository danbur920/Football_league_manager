using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IMatchService
    {
        Task AddNewMatchToTheSeason(NewMatchDTO newMatch);
        Task<List<ShortMatchInfoDTO>> GetMatchesFromSpecificSeasonForLeagueMaster(int leagueSeasonId);
        Task<EditMatchDTO> GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(int leagueSeasonId, int matchId);
        Task UpdateMatchInfo(EditMatchDTO editMatch);
        Task AddNewMatchEventToTheSeason(MatchEventDTO newMatchEvent);
        Task DeleteMatchEventFromSeason(int matchEventId);
    }
}
