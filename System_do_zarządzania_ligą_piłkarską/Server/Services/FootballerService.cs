using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class FootballerService : IFootballerService
    {
        private readonly IFootballerRepository _footballerRepository;
        private readonly IMapper _mapper;

        public FootballerService(IFootballerRepository footballerRepository, IMapper mapper)
        {
            _footballerRepository = footballerRepository;
            _mapper = mapper;
        }

        public async Task<FootballerProfileDTO> GetFootballerInfoById(int footballerId)
        {
            var footballer = await _footballerRepository.GetFootballerInfoById(footballerId);
            return _mapper.Map<FootballerProfileDTO>(footballer);
        }

        public async Task<List<FootballerStatProfileDTO>> GetFootballerStatsById(int footballerId)
        {
            var footballerStats = await _footballerRepository.GetFootballerStatsById(footballerId);
            return _mapper.Map<List<FootballerStatProfileDTO>>(footballerStats);
        }

        public async Task<List<FootballerDTO>> GetPlayersByPage(int pageNumber, int pageSize)
        {
            var players = await _footballerRepository.GetPlayersByPage(pageNumber, pageSize); // numer strony, ilość elementów na stronie
            return _mapper.Map<List<FootballerDTO>>(players);
        }

        public async Task<int> GetTotalPlayersCount()
        {
            return await _footballerRepository.GetTotalPlayersCount();
        }

        public async Task<List<ShortFootballerInfoDTO>> GetFootballersFromSpecificTeam(int teamId)
        {
            var footballers = await _footballerRepository.GetFootballersFromSpecificTeam(teamId);
            return _mapper.Map<List<ShortFootballerInfoDTO>>(footballers);
        }

        public async Task<List<FootballerTrophyCandidateDTO>> GetBasicFootballerInfoFromSpecificSeason(int leagueSeasonId)
        {
            var footballers = await _footballerRepository.GetFootballersFromSpecificSeason(leagueSeasonId);
            return _mapper.Map<List<FootballerTrophyCandidateDTO>>(footballers);
        }

        public async Task AddNewFootballerToTeam(NewFootballerDTO newFootballer) // Dodać logikę do dodawania footballers stats!
        {
            var mappedFootballer = _mapper.Map<Footballer>(newFootballer);
            await _footballerRepository.AddFootballer(mappedFootballer);
        }
    }
}
