using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly ApplicationDbContext _context;

        public LeagueRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<League>> GetLeaguesByPage(int pageNumber, int pageSize)
        {
            var leagues = await _context.Leagues.
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).
                ToListAsync();

            return leagues;
        }

        public async Task<League> GetLeagueById(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            return league;
        }

        public async Task<List<FootballerStat>> GetLeagueScorers(int leagueId)
        {
            var scorers = await _context.FootballerStats
                .Where(x => x.LeagueId == leagueId
                 && (x.Goals + x.Assists) > 0)
                .Include(x => x.Footballer)
                .ThenInclude(x => x.Team)
                .OrderByDescending(x => x.Goals)
                .ThenByDescending(x => x.Assists)
                .ThenBy(x => x.MatchesPlayed)
                .ToListAsync();

            return scorers;
        }

        public async Task<List<TeamStat>> GetLeagueTable(int leagueId)
        {
            var teamsStats = await _context.TeamStats
                .Where(x => x.LeagueId == leagueId)
                .Include(x => x.Team)
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalBalance)
                .ToListAsync();

            return teamsStats;
        }
    }
}
