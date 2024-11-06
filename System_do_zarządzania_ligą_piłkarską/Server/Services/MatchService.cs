using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository,IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task AddNewMatchToTheSeason(NewMatchDTO newMatch)
        {
            var mappedMatch = _mapper.Map<Match>(newMatch);

            mappedMatch.IsFinished = false;
            mappedMatch.Result = null;

            await _matchRepository.AddNewMatchToTheSeason(mappedMatch);
        }
    }
}
