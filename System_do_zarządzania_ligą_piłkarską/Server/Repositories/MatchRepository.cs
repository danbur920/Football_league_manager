using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
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
                Where(x => x.LeagueId == leagueSeasonId).
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
                Include(x=>x.MatchEvents).
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
            throw new NotImplementedException();
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