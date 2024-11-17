using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Models.AuxiliaryModels;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

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