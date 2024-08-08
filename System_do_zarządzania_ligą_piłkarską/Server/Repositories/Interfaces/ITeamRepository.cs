using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllTeams();
        Task<Team> GetTeamById(int teamId);
        Task<List<FootballerStat>> GetCurrentFootballersStats(int teamId);
    }
}
