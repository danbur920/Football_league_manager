using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ILeagueService
    {
        Task<List<LeagueSeasonDTO>> GetLeaguesByPage(int pageNumber, int pageSize);
        Task<LeagueSeasonProfilDTO> GetLeagueById(int id);
        Task<List<TeamStatDTO>> GetLeagueTable(int leagueId);
        Task<List<FootballerStatDTO>> GetLeagueScorers(int leagueId);

        Task CreateNewLeague(NewLeagueDTO newLeagueDto, string userId);

        // League Master Panel:

        Task<List<LeagueInfoDTO>> GetAllLeaguesByLeagueMaster(string userId);
        Task<List<LeagueSeasonDTO>> GetLeagueByLeagueMaster(string userId, int leagueInfoId);
        Task<LeagueSeasonDTO> GetSeasonByLeagueMaster(string userId, int leagueInfoId, int leagueSeasonId);
        Task DeleteLeague(int leagueId);
        Task DeleteUserFromManagement(int leagueSeasonId, string leagueMasterPrimaryId);
        Task AssignUserToManagement(int leagueSeasonId, string leagueMasterSecondaryEmail);
        Task<bool> HasLeagueManagementRights(string userId);
        Task CreateNewLeagueSeason(NewLeagueSeasonDTO newLeagueSeason);
    }
}
