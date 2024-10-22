using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ILeagueService
    {
        Task<List<LeagueSeasonDTO>> GetLeaguesByPage(int pageNumber, int pageSize);
        Task<LeagueSeasonDTO> GetLeagueById(int id);
        Task<List<TeamStatDTO>> GetLeagueTable(int leagueId);
        Task<List<FootballerStatDTO>> GetLeagueScorers(int leagueId);

        Task CreateNewLeague(NewLeagueDTO newLeagueDto);
    }
}
