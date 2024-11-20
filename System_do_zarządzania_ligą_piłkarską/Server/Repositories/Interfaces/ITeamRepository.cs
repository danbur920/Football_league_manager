using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllTeams();
        Task<Team> GetTeamById(int teamId);
        Task AddNewTeam(Team newTeam);
        Task UpdateTeam(Team teamToUpdate);
        Task<List<FootballerStat>> GetCurrentFootballersStats(int teamId);
        Task<int> GetCurrentLeagueIdByTeam(int teamId);
        Task<List<Match>> GetMatchesByTeam (int teamId, bool isFinished);

        // League Master Panel:

        Task AddTeamToTheSeason(TeamStat newTeamStat);
        Task<List<Team>> GetCreatedTeamsByLeagueMaster(string userId);
        Task DeleteTeam(Team teamToDelete);
    }
}
