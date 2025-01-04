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
            mappedMatch.GoalsHome = 0;
            mappedMatch.GoalsAway = 0;
            mappedMatch.GoalsCount = 0;

            await _matchRepository.AddNewMatchToTheSeason(mappedMatch);
        }

        public async Task<List<ShortMatchInfoDTO>> GetMatchesFromSpecificSeasonForLeagueMaster(int leagueSeasonId)
        {
            var matches = await _matchRepository.GetMatchesFromSpecificSeasonForLeagueMaster(leagueSeasonId);
            return _mapper.Map<List<ShortMatchInfoDTO>>(matches);
        }

        public async Task<MatchDetailsDTO> GetMatchDetails(int matchId)
        {
            var match = await _matchRepository.GetExtensiveMatchInfo(matchId);
            return _mapper.Map<MatchDetailsDTO>(match);
        }

        public async Task<EditMatchDTO> GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(int leagueSeasonId, int matchId)
        {
            var match = await _matchRepository.GetExtensiveMatchInfo(matchId);
            return _mapper.Map<EditMatchDTO>(match);
        }

        public async Task<List<MatchFootballerDTO>> GetLineup(int matchId, int teamId)
        {
            var matchFootballers = await _matchRepository.GetLineup(matchId, teamId);
            return _mapper.Map<List<MatchFootballerDTO>>(matchFootballers);
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

                        statsToUpdate.HomeTeamStat.GoalBalance = statsToUpdate.HomeTeamStat.GoalsScored - statsToUpdate.HomeTeamStat.GoalsConceded;
                        statsToUpdate.AwayTeamStat.GoalBalance = statsToUpdate.AwayTeamStat.GoalsScored - statsToUpdate.AwayTeamStat.GoalsConceded;

                        await _matchRepository.UpdateStatsAfterGoal(statsToUpdate);
                        break;
                    }

                case EventType.OwnGoal:
                    {
                        statsToUpdate.PrimaryFootballerStat.OwnGoals++;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.HomeTeamStat.GoalsConceded++;
                            statsToUpdate.AwayTeamStat.GoalsScored++;
                            statsToUpdate.Match.GoalsAway++;
                            statsToUpdate.Match.GoalsCount++;
                        }
                        else
                        {
                            statsToUpdate.HomeTeamStat.GoalsScored++;
                            statsToUpdate.AwayTeamStat.GoalsConceded++;
                            statsToUpdate.Match.GoalsHome++;
                            statsToUpdate.Match.GoalsCount++;
                        }

                        statsToUpdate.HomeTeamStat.GoalBalance = statsToUpdate.HomeTeamStat.GoalsScored - statsToUpdate.HomeTeamStat.GoalsConceded;
                        statsToUpdate.AwayTeamStat.GoalBalance = statsToUpdate.AwayTeamStat.GoalsScored - statsToUpdate.AwayTeamStat.GoalsConceded;

                        await _matchRepository.UpdateStatsAfterOwnGoal(statsToUpdate);
                        break;
                    }

                case EventType.YellowCard:
                    {
                        statsToUpdate.PrimaryFootballerStat.YellowCards++;
                        statsToUpdate.RefereeStat.YellowCardsGiven++;
                        statsToUpdate.Referee.TotalYellowCardsGiven++;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.Match.HomeTeamYellowCards++;
                        }
                        else
                        {
                            statsToUpdate.Match.AwayTeamYellowCards++;
                        }

                        await _matchRepository.UpdateStatsAfterCard(statsToUpdate);
                        break;
                    }

                case EventType.RedCard:
                    {
                        statsToUpdate.PrimaryFootballerStat.RedCards++;
                        statsToUpdate.RefereeStat.RedCardsGiven++;
                        statsToUpdate.Referee.TotalRedCardsGiven++;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.Match.HomeTeamRedCards++;
                        }
                        else

                        {
                            statsToUpdate.Match.AwayTeamRedCards++;
                        }

                        await _matchRepository.UpdateStatsAfterCard(statsToUpdate);
                        break;
                    }

                case EventType.Penalty:
                    {
                        statsToUpdate.PrimaryFootballerStat.Goals++;
                        statsToUpdate.RefereeStat.PenaltiesAwarded++;
                        statsToUpdate.Referee.TotalPenaltiesAwarded++;

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

                        statsToUpdate.HomeTeamStat.GoalBalance = statsToUpdate.HomeTeamStat.GoalsScored - statsToUpdate.HomeTeamStat.GoalsConceded;
                        statsToUpdate.AwayTeamStat.GoalBalance = statsToUpdate.AwayTeamStat.GoalsScored - statsToUpdate.AwayTeamStat.GoalsConceded;

                        await _matchRepository.UpdateStatsAfterPenalty(statsToUpdate);
                        break;
                    }

                case EventType.MissedPenalty:
                    {
                        statsToUpdate.RefereeStat.PenaltiesAwarded++;
                        statsToUpdate.Referee.TotalPenaltiesAwarded++;

                        await _matchRepository.UpdateStatsAfterSubstitution(statsToUpdate);
                        break;
                    }

                case EventType.Substitution:
                    {
                        statsToUpdate.PrimaryFootballerStat.SubstituteAppearances++;
                        statsToUpdate.PrimaryFootballerStat.MatchesPlayed++;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.Match.HomeTeamSubstitutions++;
                        }
                        else
                        {
                            statsToUpdate.Match.AwayTeamSubstitutions++;
                        }

                        await _matchRepository.UpdateStatsAfterSubstitution(statsToUpdate);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

        }

        public async Task AddNewMatchFootballer(NewMatchFootballerDTO newMatchFootballer)
        {
            var mappedNewMatchFootballer = _mapper.Map<MatchFootballer>(newMatchFootballer);
            await _matchRepository.AddNewMatchFootballer(mappedNewMatchFootballer);
        }

        public async Task DeleteMatchEventFromSeason(int matchEventId)
        {
            var eventToDelete = await _matchRepository.GetMatchEvent(matchEventId);
            var statsToUpdate = await _matchRepository.GetDataToUpdateAfterNewMatchEvent(eventToDelete);

            await _matchRepository.DeleteMatchEvent(eventToDelete);

            bool refersToHomeTeam = default; // sprawdza czy zdarzenie dotyczy gospodarza (jeśli false to dotyczy gościa)
            if (statsToUpdate != null)
            {
                refersToHomeTeam = statsToUpdate.PrimaryFootballerStat.TeamStatId == statsToUpdate.HomeTeamStat.Id;
            }

            switch (eventToDelete.EventType)
            {
                case EventType.Goal:
                    {
                        statsToUpdate.PrimaryFootballerStat.Goals--;

                        if (statsToUpdate.SecondaryFootballerStat != null)
                        {
                            statsToUpdate.SecondaryFootballerStat.Assists--;
                        }
                        if (refersToHomeTeam)
                        {
                            statsToUpdate.HomeTeamStat.GoalsScored--;
                            statsToUpdate.AwayTeamStat.GoalsConceded--;
                            statsToUpdate.Match.GoalsHome--;
                            statsToUpdate.Match.GoalsCount--;
                        }
                        else
                        {
                            statsToUpdate.HomeTeamStat.GoalsConceded--;
                            statsToUpdate.AwayTeamStat.GoalsScored--;
                            statsToUpdate.Match.GoalsAway--;
                            statsToUpdate.Match.GoalsCount--;
                        }

                        statsToUpdate.HomeTeamStat.GoalBalance = statsToUpdate.HomeTeamStat.GoalsScored - statsToUpdate.HomeTeamStat.GoalsConceded;
                        statsToUpdate.AwayTeamStat.GoalBalance = statsToUpdate.AwayTeamStat.GoalsScored - statsToUpdate.AwayTeamStat.GoalsConceded;

                        await _matchRepository.UpdateStatsAfterGoal(statsToUpdate);
                        break;
                    }

                case EventType.OwnGoal:
                    {
                        statsToUpdate.PrimaryFootballerStat.OwnGoals--;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.HomeTeamStat.GoalsConceded--;
                            statsToUpdate.AwayTeamStat.GoalsScored--;
                            statsToUpdate.Match.GoalsAway--;
                            statsToUpdate.Match.GoalsCount--;
                        }
                        else
                        {
                            statsToUpdate.HomeTeamStat.GoalsScored--;
                            statsToUpdate.AwayTeamStat.GoalsConceded--;
                            statsToUpdate.Match.GoalsHome--;
                            statsToUpdate.Match.GoalsCount--;
                        }

                        statsToUpdate.HomeTeamStat.GoalBalance = statsToUpdate.HomeTeamStat.GoalsScored - statsToUpdate.HomeTeamStat.GoalsConceded;
                        statsToUpdate.AwayTeamStat.GoalBalance = statsToUpdate.AwayTeamStat.GoalsScored - statsToUpdate.AwayTeamStat.GoalsConceded;

                        await _matchRepository.UpdateStatsAfterOwnGoal(statsToUpdate);
                        break;
                    }

                case EventType.YellowCard:
                    {
                        statsToUpdate.PrimaryFootballerStat.YellowCards--;
                        statsToUpdate.RefereeStat.YellowCardsGiven--;
                        statsToUpdate.Referee.TotalYellowCardsGiven--;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.Match.HomeTeamYellowCards--;
                        }
                        else
                        {
                            statsToUpdate.Match.AwayTeamYellowCards--;
                        }

                        await _matchRepository.UpdateStatsAfterCard(statsToUpdate);
                        break;
                    }

                case EventType.RedCard:
                    {
                        statsToUpdate.PrimaryFootballerStat.RedCards--;
                        statsToUpdate.RefereeStat.RedCardsGiven--;
                        statsToUpdate.Referee.TotalRedCardsGiven--;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.Match.HomeTeamRedCards--;
                        }
                        else

                        {
                            statsToUpdate.Match.AwayTeamRedCards--;
                        }

                        await _matchRepository.UpdateStatsAfterCard(statsToUpdate);
                        break;
                    }

                case EventType.Penalty:
                    {
                        statsToUpdate.PrimaryFootballerStat.Goals--;
                        statsToUpdate.RefereeStat.PenaltiesAwarded--;
                        statsToUpdate.Referee.TotalPenaltiesAwarded--;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.HomeTeamStat.GoalsScored--;
                            statsToUpdate.AwayTeamStat.GoalsConceded--;
                            statsToUpdate.Match.GoalsHome--;
                            statsToUpdate.Match.GoalsCount--;
                        }
                        else
                        {
                            statsToUpdate.HomeTeamStat.GoalsConceded--;
                            statsToUpdate.AwayTeamStat.GoalsScored--;
                            statsToUpdate.Match.GoalsAway--;
                            statsToUpdate.Match.GoalsCount--;
                        }

                        statsToUpdate.HomeTeamStat.GoalBalance = statsToUpdate.HomeTeamStat.GoalsScored - statsToUpdate.HomeTeamStat.GoalsConceded;
                        statsToUpdate.AwayTeamStat.GoalBalance = statsToUpdate.AwayTeamStat.GoalsScored - statsToUpdate.AwayTeamStat.GoalsConceded;

                        await _matchRepository.UpdateStatsAfterPenalty(statsToUpdate);
                        break;
                    }

                case EventType.MissedPenalty:
                    {
                        statsToUpdate.RefereeStat.PenaltiesAwarded--;
                        statsToUpdate.Referee.TotalPenaltiesAwarded--;

                        await _matchRepository.UpdateStatsAfterSubstitution(statsToUpdate);
                        break;
                    }

                case EventType.Substitution:
                    {
                        statsToUpdate.PrimaryFootballerStat.SubstituteAppearances--;
                        statsToUpdate.PrimaryFootballerStat.MatchesPlayed--;

                        if (refersToHomeTeam)
                        {
                            statsToUpdate.Match.HomeTeamSubstitutions--;
                        }
                        else
                        {
                            statsToUpdate.Match.AwayTeamSubstitutions--;
                        }

                        await _matchRepository.UpdateStatsAfterSubstitution(statsToUpdate);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        public async Task DeleteMatchFootballer(int matchFootballerId)
        {
            await _matchRepository.DeleteMatchFootballer(matchFootballerId);
        }

        public async Task ChangeMatchState(int matchId) // zatwierdzenie/cofnięcie meczu
        {
            var match = await _matchRepository.GetMatch(matchId);
            var statsToUpdate = await _matchRepository.GetDataToUpdateAfterChangeMatchState(match);

            if (match != null && statsToUpdate != null)
            {
                if (match.IsFinished == false) // zatwierdzanie meczu
                {
                    foreach (var footballerStat in statsToUpdate.StartingFootballerStats)
                    {
                        footballerStat.StartingAppearances++;
                        footballerStat.MatchesPlayed++;
                    }
                    statsToUpdate.LeagueSeason.MatchesPlayed++;

                    statsToUpdate.Match.IsFinished = true;
                    statsToUpdate.Match.Result = match.GoalsHome > match.GoalsAway ? 1 :
                    match.GoalsHome == match.GoalsAway ? 0 : 2;

                    statsToUpdate.Referee.TotalRefereedMatches++;
                    statsToUpdate.RefereeStat.RefereedMatches++;

                    statsToUpdate.HomeTeamStat.MatchesPlayed++;
                    statsToUpdate.AwayTeamStat.MatchesPlayed++;

                    if (statsToUpdate.Match.Result == 1)
                    {
                        statsToUpdate.HomeTeamStat.Wins++;
                        statsToUpdate.HomeTeamStat.Points += 3;

                        statsToUpdate.AwayTeamStat.Losses++;
                    }
                    else if (statsToUpdate.Match.Result == 0)
                    {
                        statsToUpdate.HomeTeamStat.Draws++;
                        statsToUpdate.HomeTeamStat.Points += 1;

                        statsToUpdate.AwayTeamStat.Draws++;
                        statsToUpdate.AwayTeamStat.Points += 1;
                    }
                    else
                    {
                        statsToUpdate.HomeTeamStat.Losses++;

                        statsToUpdate.AwayTeamStat.Wins++;
                        statsToUpdate.AwayTeamStat.Points += 3;
                    }
                }
                else // cofnięcie zatwierdzenia meczu
                {
                    foreach (var footballerStat in statsToUpdate.StartingFootballerStats)
                    {
                        footballerStat.StartingAppearances--;
                        footballerStat.MatchesPlayed--;
                    }
                    statsToUpdate.LeagueSeason.MatchesPlayed--;

                    statsToUpdate.Match.IsFinished = false;

                    statsToUpdate.Referee.TotalRefereedMatches--;
                    statsToUpdate.RefereeStat.RefereedMatches--;

                    statsToUpdate.HomeTeamStat.MatchesPlayed--;
                    statsToUpdate.AwayTeamStat.MatchesPlayed--;

                    if (statsToUpdate.Match.Result == 1)
                    {
                        statsToUpdate.HomeTeamStat.Wins--;
                        statsToUpdate.HomeTeamStat.Points -= 3;

                        statsToUpdate.AwayTeamStat.Losses--;
                    }
                    else if (statsToUpdate.Match.Result == 0)
                    {
                        statsToUpdate.HomeTeamStat.Draws--;
                        statsToUpdate.HomeTeamStat.Points -= 1;

                        statsToUpdate.AwayTeamStat.Draws--;
                        statsToUpdate.AwayTeamStat.Points -= 1;
                    }
                    else
                    {
                        statsToUpdate.HomeTeamStat.Losses--;

                        statsToUpdate.AwayTeamStat.Wins--;
                        statsToUpdate.AwayTeamStat.Points -= 3;
                    }
                    statsToUpdate.Match.Result = null;

                }

                await _matchRepository.UpdateAfterChangeMatchState(statsToUpdate);
            }
        }
    }
}
