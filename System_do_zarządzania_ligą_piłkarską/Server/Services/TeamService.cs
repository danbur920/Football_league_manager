using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IUserService userService, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<List<TeamDTO>> GetAllTeams()
        {
            var teams = await _teamRepository.GetAllTeams();
            return _mapper.Map<List<TeamDTO>>(teams);
        }

        public async Task<TeamDTO> GetTeamById(int teamId)
        {
            var team = await _teamRepository.GetTeamById(teamId);
            var mappedTeam = _mapper.Map<TeamDTO>(team);

            mappedTeam.LeagueId = await _teamRepository.GetCurrentLeagueIdByTeam(teamId);
            return mappedTeam;
        }

        public async Task<List<FootballerStatDTO>> GetCurrentFootballersStats(int teamId)
        {
            var currentFootballersStats = await _teamRepository.GetCurrentFootballersStats(teamId);
            return _mapper.Map<List<FootballerStatDTO>>(currentFootballersStats);
        }

        public async Task<List<MatchDTO>> GetMatchesByTeam(int teamId, bool isFinished)
        {
            var matches = await _teamRepository.GetMatchesByTeam(teamId, isFinished);
            return _mapper.Map<List<MatchDTO>>(matches);
        }

        public async Task<List<SeasonTeamStatsDTO>> GetSeasonsWithTeamStatsByTeam(int teamId)
        {
            var leagueSeasons = await _teamRepository.GetSeasonsWithTeamStatsByTeam(teamId);
            return _mapper.Map<List<SeasonTeamStatsDTO>>(leagueSeasons);
        }

        // League Master Panel:

        public async Task<List<ShortTeamInfoDTO>> GetAllTeamsForLeagueMaster()
        {
            var teams = await _teamRepository.GetAllTeams();
            return _mapper.Map<List<ShortTeamInfoDTO>>(teams);
        }

        public async Task<List<TeamInfoDTO>> GetCreatedTeamsByLeagueMaster(string userId)
        {
            var teams = await _teamRepository.GetCreatedTeamsByLeagueMaster(userId);
            var mappedTeams = _mapper.Map<List<TeamInfoDTO>>(teams);

            foreach (var team in mappedTeams)
            {
                var coach = teams.FirstOrDefault(x => x.Id == team.Id)?.Coach;
                if (coach != null)
                {
                    team.HasCoach = true;
                    team.Coach = _mapper.Map<ShortCoachInfoDTO>(coach);
                }
            }

            return mappedTeams;
        }

        public async Task AddTeamToTheSeason(NewTeamStatDTO newTemStat)
        {
            var teamToAdd = _mapper.Map<TeamStat>(newTemStat);
            teamToAdd.CurrentLeague = true;

            await _teamRepository.AddTeamToTheSeason(teamToAdd);
        }

        public async Task<TeamManageDTO> GetTeamToManage(int teamId)
        {
            var team = await _teamRepository.GetTeamToManage(teamId);
            var mappedTeam = _mapper.Map<TeamManageDTO>(team);
            return mappedTeam;
        }

        public async Task AddNewTeam(NewTeamDTO newTeam)
        {
            string teamCoachId = string.Empty;
            if (newTeam.CoachEmail != null)
            {
                teamCoachId = await _userService.GetUserIdByEmailAddress(newTeam.CoachEmail);
            }

            var mappedNewTeam = _mapper.Map<Team>(newTeam);

            if (teamCoachId != string.Empty && teamCoachId != null)
            {
                mappedNewTeam.CoachId = teamCoachId;
            }

            await _teamRepository.AddNewTeam(mappedNewTeam);
        }
        public async Task DeleteTeam(int teamId)
        {
            var teamToDelete = await _teamRepository.GetTeamById(teamId);
            await _teamRepository.DeleteTeam(teamToDelete);
        }

        public async Task DeleteCoachFromTeam(int teamId)
        {
            var team = await _teamRepository.GetTeamById(teamId);

            team.CoachId = null;
            await _teamRepository.UpdateTeam(team);
        }

        public async Task<bool> AssignCoachToTeam(int teamId, string coachEmail)
        {
            var userId = await _userService.GetUserIdByEmailAddress(coachEmail);

            if (userId != null)
            {
                var team = await _teamRepository.GetTeamById(teamId);
                team.CoachId = userId;

                await _teamRepository.UpdateTeam(team);
                return true;
            }
            return false;
        }

        public async Task EditTeam(EditTeamDTO editTeam)
        {
            var currentTeam = await _teamRepository.GetTeamById(editTeam.Id);

            currentTeam.Stadium = editTeam.Stadium;
            currentTeam.Name = editTeam.Name;
            currentTeam.YearOfFoundation = editTeam.YearOfFoundation;
            currentTeam.City = editTeam.City;
            currentTeam.Country = editTeam.Country;

            await _teamRepository.UpdateTeam(currentTeam);
        }
    }
}