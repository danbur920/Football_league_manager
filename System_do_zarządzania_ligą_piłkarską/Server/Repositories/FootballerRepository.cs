using Microsoft.EntityFrameworkCore;
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

        public async Task<FootballerStat> GetFootballerInfoById(int footballerId)
        {
            var footballer = await _context.FootballerStats.
                Where(x => x.Id == footballerId).
                Include(x => x.Footballer).
                FirstOrDefaultAsync();

            return footballer;
        }

        public async Task<List<Footballer>> GetPlayersByPage(int pageNumber, int pageSize)
        {
            var players = await _context.Footballers.
                Include(x => x.Team).
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).
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
    }
}
