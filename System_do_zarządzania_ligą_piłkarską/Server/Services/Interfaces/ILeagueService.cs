using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ILeagueService
    {
        Task<List<LeagueDTO>> GetAllLeagues();
        Task<LeagueDTO> GetLeagueById(int id);
        Task<List<TeamStatDTO>> GetLeagueTable(int leagueId);
        Task<List<FootballerStatDTO>> GetLeagueScorers(int leagueId);
    }
}
