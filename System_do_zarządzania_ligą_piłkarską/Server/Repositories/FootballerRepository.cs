using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class FootballerRepository : IFootballerRepository
    {
        private readonly ApplicationDbContext _context;

        public FootballerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Footballer> GetFootballerInfoById(int footballerId)
        {
            var footballer = await _context.Footballers.
                Where(x => x.Id == footballerId).
                Include(x=>x.Team).
                Include(x => x.Image).
                FirstOrDefaultAsync(); 

            return footballer;
        }

        public async Task<List<FootballerStat>> GetFootballerStatsById(int footballerId)
        {
            var footballerStats = await _context.FootballerStats.
                Where(x => x.FootballerId == footballerId).
                Include(x => x.LeagueSeason).
                ThenInclude(x=>x.LeagueInfo).
                ToListAsync();

            return footballerStats;
        }

        public async Task<List<Footballer>> GetPlayersByPage(int pageNumber, int pageSize)
        {
            var players = await _context.Footballers.
                Include(x => x.Team).
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).
                OrderBy(x => x.Team.Name).
                ThenBy(x => x.FirstName).
                ThenBy(x => x.LastName).
                ToListAsync();
            return players;
        }

        public async Task<int> GetTotalPlayersCount()
        {
            int playersCount = await _context.Footballers.CountAsync();
            return playersCount;
        }

        public async Task<List<Footballer>> GetFootballersFromSpecificTeam(int teamId)
        {
            var footballers = await _context.Footballers.
                Where(x => x.TeamId == teamId).
                ToListAsync();

            return footballers;
        }

        public async Task AddFootballer(Footballer footballer)
        {
            await _context.Footballers.AddAsync(footballer);
            await _context.SaveChangesAsync();

            await AddFootballerStats(footballer);
            await _context.SaveChangesAsync();
        }

        public async Task AddFootballerStats(Footballer footballer)
        {
            var currentTeamStats = await _context.TeamStats.
                Where(x => x.TeamId == footballer.TeamId && x.CurrentLeague == true).
                ToListAsync();

            foreach (var teamStat in currentTeamStats)
            {
                var existsFootballerStats = await _context.FootballerStats.
                    Where(x => x.FootballerId == footballer.Id && x.TeamStatId == teamStat.Id).
                    FirstOrDefaultAsync();

                if (existsFootballerStats == null)
                {
                    await _context.FootballerStats.AddAsync(new FootballerStat
                    {
                        FootballerId = footballer.Id,
                        LeagueSeasonId = teamStat.LeagueSeasonId,
                        TeamStatId = teamStat.Id
                    });
                }
            }
        }
    }
}
