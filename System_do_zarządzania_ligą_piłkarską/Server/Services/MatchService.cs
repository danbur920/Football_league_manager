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
            await _matchRepository.AddNewMatchEventToTheSeason(mappedEvent);

            var statsToUpdate = await _matchRepository.GetDataToUpdateAfterNewMatchEvent(mappedEvent);

            bool refersToHomeTeam = default; // sprawdza czy zdarzenie dotyczy gospodarza (jeśli false to dotyczy gościa)
            if (statsToUpdate != null)
            {
                refersToHomeTeam = statsToUpdate.PrimaryFootballerStat.TeamStatId == statsToUpdate.HomeTeamStat.Id ? true : false;
            }
                

            switch (mappedEvent.EventType)
            {
                case EventType.Goal:
                    {
                        statsToUpdate.PrimaryFootballerStat.Goals++;

                        if (statsToUpdate.SecondaryFootballerStat != null)
                        {
                            statsToUpdate.SecondaryFootballerStat.Assists++;
                        }
                        if (refersToHomeTeam)
                        {
                            statsToUpdate.HomeTeamStat.GoalsScored++;
                            statsToUpdate.AwayTeamStat.GoalsConceded++;
                            statsToUpdate.Match.GoalsHome++;
                            statsToUpdate.Match.GoalsCount++;
                        }
                        else
                        {
                            statsToUpdate.HomeTeamStat.GoalsConceded++;
                            statsToUpdate.AwayTeamStat.GoalsScored++;
                            statsToUpdate.Match.GoalsAway++;
                            statsToUpdate.Match.GoalsCount++;
                        }
                        await _matchRepository.UpdateStatsAfterGoal(mappedEvent);
                        break;
                    }

                case EventType.OwnGoal:
                    {
                        await _matchRepository.UpdateStatsAfterOwnGoal(mappedEvent);
                        break;
                    }

                case EventType.YellowCard:
                    {
                        await _matchRepository.UpdateStatsAfterYellowCard(mappedEvent);
                        break;
                    }

                case EventType.RedCard:
                    {
                        await _matchRepository.UpdateStatsAfterRedCard(mappedEvent);
                        break;
                    }

                case EventType.Penalty:
                    {
                        await _matchRepository.UpdateStatsAfterPenalty(mappedEvent);
                        break;
                    }

                case EventType.Substitution:
                    {
                        await _matchRepository.UpdateStatsAfterSubstitution(mappedEvent);
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
