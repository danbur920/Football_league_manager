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

        public async Task<List<ShortMatchInfoDTO>> GetMatchesFromSpecificSeasonForLeagueMaster(int leagueSeasonId)
        {
            var matches = await _matchRepository.GetMatchesFromSpecificSeasonForLeagueMaster(leagueSeasonId);
            return _mapper.Map<List<ShortMatchInfoDTO>>(matches);
        }


        public async Task<EditMatchDTO> GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(int leagueSeasonId, int matchId)
        {
            var match = await _matchRepository.GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(leagueSeasonId, matchId);
            return _mapper.Map<EditMatchDTO>(match);
        }
    }
}
