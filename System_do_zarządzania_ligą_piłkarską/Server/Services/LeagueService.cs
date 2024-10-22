using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;

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
        public async Task<List<LeagueSeasonDTO>> GetLeaguesByPage(int pageNumber, int pageSize)
        {
            var leagues = await _leagueRepository.GetLeaguesByPage(pageNumber, pageSize);

            // Logowanie danych do debugowania
            foreach (var league in leagues)
            {
                Console.WriteLine($"League ID: {league.Id}, LeagueInfoId: {league.LeagueInfoId}");
            }

            var leagueSeasonDTOs = _mapper.Map<List<LeagueSeasonDTO>>(leagues);

            // Logowanie po mapowaniu
            foreach (var leagueDTO in leagueSeasonDTOs)
            {
                Console.WriteLine($"LeagueDTO ID: {leagueDTO.Id}, LeagueInfoId: {leagueDTO.LeagueInfoId}");
            }

            return leagueSeasonDTOs;
        }

        public async Task<LeagueSeasonDTO> GetLeagueById(int id)
        {
            var league = await _leagueRepository.GetLeagueById(id);
            return _mapper.Map<LeagueSeasonDTO>(league);
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

        public async Task CreateNewLeague(NewLeagueDTO newLeagueDto)
        {
            var leagueInfo = _mapper.Map<LeagueInfo>(newLeagueDto.LeagueInfo);
            var leagueSeason = _mapper.Map<LeagueSeason>(newLeagueDto.LeagueSeason);

            await _leagueRepository.AddNewLeagueInfo(leagueInfo);
            leagueSeason.LeagueInfoId = leagueInfo.Id;
            await _leagueRepository.AddNewLeagueSeason(leagueSeason);
        }
    }
}
