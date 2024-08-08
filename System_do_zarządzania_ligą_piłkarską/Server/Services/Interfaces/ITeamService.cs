using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<TeamDTO>> GetAllTeams();
        Task<TeamDTO> GetTeamById(int teamId);
        Task<List<FootballerStatDTO>> GetCurrentFootballersStats(int teamId);
    }
}
