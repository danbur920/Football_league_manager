using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

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
        public async Task<List<FootballerDTO>> GetPlayers(int pageNumber, int pageSize)
        {
            var players = await _footballerRepository.GetPlayers(pageNumber, pageSize);
            return _mapper.Map<List<FootballerDTO>>(players);
        }
    }
}
