using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class TrophyService : ITrophyService
    {
        private readonly ITrophyRepository _trophyRepository;
        private readonly IMapper _mapper;

        public TrophyService(ITrophyRepository trophyRepository, IMapper mapper)
        {
            _trophyRepository = trophyRepository;
            _mapper = mapper;
        }

        public async Task<List<TrophyDTO>> GetTrophies()
        {
            var trophies = await _trophyRepository.GetTrophies();
            return _mapper.Map<List<TrophyDTO>>(trophies);
        }

        public async Task AddNewTrophy(NewTrophyDTO newTrophy)
        {
            var mappedTrophy = _mapper.Map<Trophy>(newTrophy);
            await _trophyRepository.AddTrophy(mappedTrophy);
        }

        public async Task<List<TrophyDTO>> GetCreatedTrophiesByLeagueMaster(string userId)
        {
            var trophies = await _trophyRepository.GetCreatedTrophiesByLeagueMaster(userId);
            return _mapper.Map<List<TrophyDTO>>(trophies);
        }

        public async Task DeleteTrophy(int trophyId)
        {
            await _trophyRepository.DeleteTrophy(trophyId);
        }
    }
}
