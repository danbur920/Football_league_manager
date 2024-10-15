using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

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
    }
}
