using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Models.AuxiliaryModels;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Updates;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewMatchToTheSeason(Match newMatch)
        {
            await _context.Matches.AddAsync(newMatch);
            await _context.SaveChangesAsync();
        }

        public async Task<Match> GetMatch(int matchId)
        {
            var match = await _context.Matches.FindAsync(matchId);
            return match;
        }

        public async Task UpdateMatch(Match match)
        {
            _context.Matches.Update(match);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Match>> GetMatchesFromSpecificSeasonForLeagueMaster(int leagueSeasonId)
        {
            var matches = await _context.Matches.
                Where(x => x.LeagueSeasonId == leagueSeasonId).
                Include(x => x.HomeTeam).
                Include(x => x.AwayTeam).
                ToListAsync();

            return matches;
        }

        public async Task<Match> GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(int leagueSeasonId, int matchId)
        {
            var match = await _context.Matches.Where(x => x.Id == matchId).
                Include(x => x.HomeTeam).
                Include(x => x.AwayTeam).
                Include(x => x.MatchEvents).
                FirstOrDefaultAsync();

            return match;
        }

        public async Task UpdateMatchInfo(Match editMatch)
        {
            _context.Matches.Update(editMatch);
            await _context.SaveChangesAsync();
        }

        public async Task<MatchEvent> GetMatchEvent(int matchEventId)
        {
            var matchEvent = await _context.MatchEvents.FindAsync(matchEventId);
            return matchEvent;
        }

        public async Task<List<MatchFootballer>> GetLineup(int matchId, int teamId)
        {
            var lineup = await _context.MatchFootballers.
                Where(x => x.MatchId == matchId && x.TeamId == teamId).
                Include(x => x.Footballer).
                ToListAsync();

            return lineup;
        }

        public async Task AddNewMatchEventToTheSeason(MatchEvent newMatchEvent)
        {
            await _context.MatchEvents.AddAsync(newMatchEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<MatchEventStatsUpdate> GetDataToUpdateAfterNewMatchEvent(MatchEvent newMatchEvent)
        {
            var match = await _context.Matches.FindAsync(newMatchEvent.MatchId);

            var primaryFootballerStat = await _context.FootballerStats.
                Where(x => x.FootballerId == newMatchEvent.PrimaryFootballerId && x.LeagueSeasonId == newMatchEvent.LeagueSeasonId).
                FirstOrDefaultAsync();

            var secondaryFootballerStat = await _context.FootballerStats.
                Where(x => x.FootballerId == newMatchEvent.SecondaryFootballerId && x.LeagueSeasonId == newMatchEvent.LeagueSeasonId).
                FirstOrDefaultAsync();

            var homeTeamStat = await _context.TeamStats.
                Where(x => x.TeamId == match.HomeTeamId && x.LeagueSeasonId == newMatchEvent.LeagueSeasonId).
                FirstOrDefaultAsync();

            var awayTeamStat = await _context.TeamStats.
                Where(x => x.TeamId == match.AwayTeamId && x.LeagueSeasonId == newMatchEvent.LeagueSeasonId).
                FirstOrDefaultAsync();

            var leagueSeason = await _context.LeagueSeasons.FindAsync(newMatchEvent.LeagueSeasonId);

            var refereeStat = await _context.RefereeStats.
                Where(x => x.RefereeId == newMatchEvent.RefereeId && x.LeagueSeasonId == newMatchEvent.LeagueSeasonId).
                FirstOrDefaultAsync();

            var referee = await _context.Referees.FindAsync(newMatchEvent.RefereeId);

            var statsToUpdate = new MatchEventStatsUpdate()
            {
                PrimaryFootballerStat = primaryFootballerStat,
                SecondaryFootballerStat = secondaryFootballerStat,
                HomeTeamStat = homeTeamStat,
                AwayTeamStat = awayTeamStat,
                LeagueSeason = leagueSeason,
                Match = match,
                Referee = referee,
                RefereeStat = refereeStat
            };

            return statsToUpdate;
        }

        public async Task UpdateStatsAfterGoal(MatchEventStatsUpdate statsUpdate)
        {
            _context.FootballerStats.Update(statsUpdate.PrimaryFootballerStat);

            if (statsUpdate.SecondaryFootballerStat != null)
                _context.FootballerStats.Update(statsUpdate.SecondaryFootballerStat);

            _context.TeamStats.Update(statsUpdate.HomeTeamStat);
            _context.TeamStats.Update(statsUpdate.AwayTeamStat);
            _context.Matches.Update(statsUpdate.Match);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatsAfterOwnGoal(MatchEventStatsUpdate statsUpdate)
        {
            _context.FootballerStats.Update(statsUpdate.PrimaryFootballerStat);

            _context.TeamStats.Update(statsUpdate.HomeTeamStat);
            _context.TeamStats.Update(statsUpdate.AwayTeamStat);
            _context.Matches.Update(statsUpdate.Match);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatsAfterCard(MatchEventStatsUpdate statsUpdate)
        {
            _context.FootballerStats.Update(statsUpdate.PrimaryFootballerStat);
            _context.Referees.Update(statsUpdate.Referee);
            _context.RefereeStats.Update(statsUpdate.RefereeStat);
            _context.Matches.Update(statsUpdate.Match);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatsAfterPenalty(MatchEventStatsUpdate statsUpdate)
        {
            _context.FootballerStats.Update(statsUpdate.PrimaryFootballerStat);
            _context.Referees.Update(statsUpdate.Referee);
            _context.RefereeStats.Update(statsUpdate.RefereeStat);
            _context.TeamStats.Update(statsUpdate.HomeTeamStat);
            _context.TeamStats.Update(statsUpdate.AwayTeamStat);
            _context.Matches.Update(statsUpdate.Match);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatsAfterMissedPenalty(MatchEventStatsUpdate statsUpdate)
        {
            _context.Referees.Update(statsUpdate.Referee);
            _context.RefereeStats.Update(statsUpdate.RefereeStat);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatsAfterSubstitution(MatchEventStatsUpdate statsUpdate)
        {
            _context.FootballerStats.Update(statsUpdate.PrimaryFootballerStat);
            _context.Matches.Update(statsUpdate.Match);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMatchEvent(MatchEvent matchEventToDelete)
        {
            _context.MatchEvents.Remove(matchEventToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewMatchFootballer(MatchFootballer newMatchFootballer)
        {
            await _context.MatchFootballers.AddAsync(newMatchFootballer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMatchFootballer(int matchFootballerId)
        {
            var matchFootballerToDelete = await _context.MatchFootballers.FindAsync(matchFootballerId);
            if (matchFootballerToDelete != null)
            {
                _context.MatchFootballers.Remove(matchFootballerToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MatchStateUpdate> GetDataToUpdateAfterChangeMatchState(Match match)
        {
            var matchUpdate = new MatchUpdateMatchState
            {
                Id = match.Id,
                IsFinished = match.IsFinished,
                Result = match.Result
            };

            var startingLineup = await _context.MatchFootballers
                .Where(x => x.MatchId == match.Id && x.IsStartingPlayer == true)
                .ToListAsync(); // pobieramy wyjściowy skład

            var footballerIds = startingLineup.Select(x => x.FootballerId).ToList();

            var startingFootballers = await _context.FootballerStats
                .Where(stat => footballerIds.Contains(stat.FootballerId))
                .Select(x => new FootballerStatUpdateMatchState
                {
                    Id = x.Id,
                    MatchesPlayed = x.MatchesPlayed,
                    StartingAppearances = x.StartingAppearances
                })
                .ToListAsync();

            var leagueSeason = await _context.LeagueSeasons
                .Where(x => x.Id == match.LeagueSeasonId)
                .Select(x => new LeagueSeasonUpdateMatchState
                {
                    Id = x.Id,
                    MatchesPlayed = x.MatchesPlayed
                })
                .FirstOrDefaultAsync();

            var referee = await _context.Referees
                .Where(x => x.Id == match.RefereeId)
                .Select(x => new RefereeUpdateMatchState
                {
                    Id = x.Id,
                    TotalRefereedMatches = x.TotalRefereedMatches
                })
                .FirstOrDefaultAsync();

            var refereeStat = await _context.RefereeStats
                .Where(x => x.RefereeId == match.RefereeId && x.LeagueSeasonId == match.LeagueSeasonId)
                .Select(x => new RefereeStatUpdateMatchState
                {
                    Id = x.Id,
                    RefereedMatches = x.RefereedMatches
                })
                .FirstOrDefaultAsync();

            var homeTeamStat = await _context.TeamStats
                .Where(x => x.TeamId == match.HomeTeamId && x.LeagueSeasonId == match.LeagueSeasonId)
                .Select(x => new TeamStatUpdateMatchState
                {
                    Id = x.Id,
                    MatchesPlayed = x.MatchesPlayed,
                    Wins = x.Wins,
                    Draws = x.Draws,
                    Losses = x.Losses,
                    Points = x.Points
                })
                .FirstOrDefaultAsync();

            var awayTeamStat = await _context.TeamStats
                .Where(x => x.TeamId == match.AwayTeamId && x.LeagueSeasonId == match.LeagueSeasonId)
                .Select(x => new TeamStatUpdateMatchState
                {
                    Id = x.Id,
                    MatchesPlayed = x.MatchesPlayed,
                    Wins = x.Wins,
                    Draws = x.Draws,
                    Losses = x.Losses,
                    Points = x.Points
                })
                .FirstOrDefaultAsync();

            MatchStateUpdate statsToUpdate = new MatchStateUpdate
            {
                StartingFootballerStats = startingFootballers,
                LeagueSeason = leagueSeason,
                Match = matchUpdate,
                Referee = referee,
                RefereeStat = refereeStat,
                HomeTeamStat = homeTeamStat,
                AwayTeamStat = awayTeamStat
            };

            return statsToUpdate;
        }

        public async Task UpdateAfterChangeMatchState(MatchStateUpdate matchStateUpdate)
        {
            foreach (var footballerStat in matchStateUpdate.StartingFootballerStats)
            {
                var footballerStatEntity = new FootballerStat
                {
                    Id = footballerStat.Id,
                    MatchesPlayed = footballerStat.MatchesPlayed,
                    StartingAppearances = footballerStat.StartingAppearances
                };
                _context.FootballerStats.Attach(footballerStatEntity);
                _context.Entry(footballerStatEntity).Property(e => e.MatchesPlayed).IsModified = true;
                _context.Entry(footballerStatEntity).Property(e => e.StartingAppearances).IsModified = true;
            }

            var leagueSeasonEntity = new LeagueSeason
            {
                Id = matchStateUpdate.LeagueSeason.Id,
                MatchesPlayed = matchStateUpdate.LeagueSeason.MatchesPlayed
            };
            _context.LeagueSeasons.Attach(leagueSeasonEntity);
            _context.Entry(leagueSeasonEntity).Property(x => x.MatchesPlayed).IsModified = true;


            var matchToUpdate = await _context.Matches.FindAsync(matchStateUpdate.Match.Id);
            matchToUpdate.IsFinished = matchStateUpdate.Match.IsFinished;
            matchToUpdate.Result = matchStateUpdate.Match.Result;
                
            //var matchEntity = new Match
            //{
            //    Id = matchStateUpdate.Match.Id,
            //    IsFinished = matchStateUpdate.Match.IsFinished,
            //    Result = matchStateUpdate.Match.Result
            //};
            //_context.Matches.Attach(matchEntity); // tu wywala błąd
            //_context.Entry(matchEntity).Property(x => x.IsFinished).IsModified = true;
            //_context.Entry(matchEntity).Property(x => x.Result).IsModified = true;

            // altenatywa:
            //var trackedEntity = _context.ChangeTracker.Entries<Match>()
            //    .FirstOrDefault(e => e.Entity.Id == matchEntity.Id);

            //if (trackedEntity == null)
            //{
            //    _context.Matches.Attach(matchEntity);
            //}
            //else
            //{
            //    trackedEntity.CurrentValues.SetValues(matchEntity);
            //    trackedEntity.State = EntityState.Modified;
            //}
            // -------------------------------


            var refereeEntity = new Referee
            {
                Id = matchStateUpdate.Referee.Id,
                TotalRefereedMatches = matchStateUpdate.Referee.TotalRefereedMatches
            };
            _context.Referees.Attach(refereeEntity);
            _context.Entry(refereeEntity).Property(x => x.TotalRefereedMatches).IsModified = true;

            var refereeStatEntity = new RefereeStat
            {
                Id = matchStateUpdate.RefereeStat.Id,
                RefereedMatches = matchStateUpdate.RefereeStat.RefereedMatches
            };
            _context.RefereeStats.Attach(refereeStatEntity);
            _context.Entry(refereeStatEntity).Property(x => x.RefereedMatches).IsModified = true;

            var teamStatHome = new TeamStat
            {
                Id = matchStateUpdate.HomeTeamStat.Id,
                MatchesPlayed = matchStateUpdate.HomeTeamStat.MatchesPlayed,
                Wins = matchStateUpdate.HomeTeamStat.Wins,
                Draws = matchStateUpdate.HomeTeamStat.Draws,
                Losses = matchStateUpdate.HomeTeamStat.Losses,
                Points = matchStateUpdate.HomeTeamStat.Points
            };

            _context.TeamStats.Attach(teamStatHome);
            _context.Entry(teamStatHome).Property(x => x.MatchesPlayed).IsModified = true;
            _context.Entry(teamStatHome).Property(x => x.Wins).IsModified = true;
            _context.Entry(teamStatHome).Property(x => x.Draws).IsModified = true;
            _context.Entry(teamStatHome).Property(x => x.Losses).IsModified = true;
            _context.Entry(teamStatHome).Property(x => x.Points).IsModified = true;

            var teamStatAway = new TeamStat
            {
                Id = matchStateUpdate.AwayTeamStat.Id,
                MatchesPlayed = matchStateUpdate.AwayTeamStat.MatchesPlayed,
                Wins = matchStateUpdate.AwayTeamStat.Wins,
                Draws = matchStateUpdate.AwayTeamStat.Draws,
                Losses = matchStateUpdate.AwayTeamStat.Losses,
                Points = matchStateUpdate.AwayTeamStat.Points
            };

            _context.TeamStats.Attach(teamStatAway);
            _context.Entry(teamStatAway).Property(x => x.MatchesPlayed).IsModified = true;
            _context.Entry(teamStatAway).Property(x => x.Wins).IsModified = true;
            _context.Entry(teamStatAway).Property(x => x.Draws).IsModified = true;
            _context.Entry(teamStatAway).Property(x => x.Losses).IsModified = true;
            _context.Entry(teamStatAway).Property(x => x.Points).IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
                foreach (var entry in ex.Entries)
                {
                    Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
                }
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }

        }
    }
}

// Początkowy pomysł:

//var match = await _context.Matches.
//    Where(x => x.Id == matchId).
//    Include(x => x.HomeTeam).
//    ThenInclude(x => x.TeamStats.Where(x => x.LeagueId == leagueSeasonId)).
//    Include(x => x.HomeTeam.Footballers).
//    ThenInclude(x => x.FootballerStats.Where(x => x.LeagueId == leagueSeasonId)).
//    Include(x => x.AwayTeam).
//    ThenInclude(x => x.TeamStats.Where(x => x.LeagueId == leagueSeasonId)).
//    Include(x => x.AwayTeam.Footballers).
//    ThenInclude(x => x.FootballerStats.Where(x => x.LeagueId == leagueSeasonId)).
//    Include(x => x.League).
//    Include(x => x.Referee).
//    ThenInclude(x => x.RefereeStats.Where(x => x.LeagueId == leagueSeasonId)).
//    Include(x => x.MatchEvents).
//    FirstOrDefaultAsync();