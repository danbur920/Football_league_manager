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
        public async Task<List<LeagueSeason>> GetLeaguesByPage(int pageNumber, int pageSize)
        {
            var leagues = await _context.LeagueSeasons.
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).
                Include(x => x.LeagueInfo).
                ToListAsync();

            return leagues;
        }

        public async Task<LeagueSeason> GetLeagueById(int id)
        {
            var league = await _context.LeagueSeasons.Include(x => x.LeagueInfo).FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task AddNewLeagueInfo(LeagueInfo leagueInfo)
        {
            await _context.LeagueInfos.AddAsync(leagueInfo);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewLeagueSeason(LeagueSeason leagueSeason)
        {
            await _context.LeagueSeasons.AddAsync(leagueSeason);
            await _context.SaveChangesAsync();
        }
    }
}
