using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
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
    }
}