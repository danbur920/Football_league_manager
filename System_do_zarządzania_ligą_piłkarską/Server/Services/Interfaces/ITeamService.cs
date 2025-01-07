using Microsoft.AspNetCore.Mvc;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<TeamDTO>> GetAllTeams();
        Task<TeamDTO> GetTeamById(int teamId);
        Task<List<SeasonTeamStatsDTO>> GetSeasonsWithTeamStatsByTeam(int teamId);
        Task<List<FootballerStatDTO>> GetCurrentFootballersStats(int teamId);
        Task<List<MatchDTO>> GetMatchesByTeam(int teamId, bool isFinished);

        // League Master Panel:

        Task<List<ShortTeamInfoDTO>> GetAllTeamsForLeagueMaster();
        Task<List<TeamInfoDTO>> GetCreatedTeamsByLeagueMaster(string userId);
        Task AddTeamToTheSeason(NewTeamStatDTO newTeamStat);
        Task AddNewTeam(NewTeamDTO newTeam);
        Task<TeamManageDTO> GetTeamToManage(int teamId);
        Task DeleteTeam(int teamId);
        Task EditTeam(EditTeamDTO editTeam);
        Task DeleteCoachFromTeam(int teamId);
        Task<bool> AssignCoachToTeam(int teamId, string coachEmail);
    }
}
