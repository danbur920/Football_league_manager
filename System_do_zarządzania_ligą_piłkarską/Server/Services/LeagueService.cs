using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        private readonly IMapper _mapper;

        public LeagueService(ILeagueRepository leagueRepository, IMapper mapper)
        {
            _leagueRepository = leagueRepository;
            _mapper = mapper;
        }
        public async Task<List<LeagueDTO>> GetAllLeagues()
        {
            var leagues = await _leagueRepository.GetAllLeagues();
            return _mapper.Map<List<LeagueDTO>>(leagues);
        }

        public async Task<LeagueDTO> GetLeagueById(int id)
        {
            var league = await _leagueRepository.GetLeagueById(id);
            return _mapper.Map<LeagueDTO>(league);
        }

        public async Task<List<FootballerStatDTO>> GetLeagueScorers(int leagueId)
        {
            var scorers = await _leagueRepository.GetLeagueScorers(leagueId);
            return _mapper.Map<List<FootballerStatDTO>>(scorers);
        }

        public async Task<List<TeamStatDTO>> GetLeagueTable(int leagueId)
        {
            var teamsStats = await _leagueRepository.GetLeagueTable(leagueId);
            return _mapper.Map<List<TeamStatDTO>>(teamsStats);
        }
    }
}
