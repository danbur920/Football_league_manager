using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IFootballerService
    {
        Task<List<FootballerDTO>>GetPlayersByPage(int pageNumber, int pageSize);
        Task<int> GetTotalPlayersCount();
        Task<FootballerProfileDTO> GetFootballerInfoById(int footballerId);
        Task<List<FootballerStatProfileDTO>> GetFootballerStatsById (int footballerId);
        Task<List<ShortFootballerInfoDTO>> GetFootballersFromSpecificTeam(int teamId);
        Task<List<FootballerTrophyCandidateDTO>> GetBasicFootballerInfoFromSpecificSeason(int leagueSeasonId);
        Task AddNewFootballerToTeam(NewFootballerDTO newFootballer);
    }
}
