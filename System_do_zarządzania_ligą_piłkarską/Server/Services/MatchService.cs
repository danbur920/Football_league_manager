using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;
using EventType = System_do_zarządzania_ligą_piłkarską.Shared.Enums.EventType;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchService(IMatchRepository matchRepository, IMapper mapper)
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

        public async Task UpdateMatchInfo(EditMatchDTO editMatch)
        {
            var matchToEdit = await _matchRepository.GetMatch(editMatch.Id);

            if (matchToEdit != null)
            {
                matchToEdit.HomeTeamId = editMatch.HomeTeamId;
                matchToEdit.AwayTeamId = editMatch.AwayTeamId;
                matchToEdit.RefereeId = editMatch.RefereeId;
                matchToEdit.Round = editMatch.Round;
                matchToEdit.MatchDate = editMatch.MatchDate;
                matchToEdit.MatchTime = editMatch.MatchTime;
                matchToEdit.FootballStadium = editMatch.FootballStadium;

                await _matchRepository.UpdateMatchInfo(matchToEdit);
            }
        }

        public async Task AddNewMatchEventToTheSeason(MatchEventDTO newMatchEvent)
        {
            var mappedEvent = _mapper.Map<MatchEvent>(newMatchEvent);

            switch (mappedEvent.EventType)
            {
                case EventType.Goal:
                    {
                        break;
                    }

                case EventType.OwnGoal:
                    {
                        break;
                    }

                case EventType.YellowCard:
                    {
                        break;
                    }

                case EventType.RedCard:
                    {
                        break;
                    }

                case EventType.Penalty:
                    {
                        break;
                    }

                case EventType.MissedPenalty:
                    {
                        break;
                    }

                case EventType.Substitution:
                    {
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

        }
    }
}
