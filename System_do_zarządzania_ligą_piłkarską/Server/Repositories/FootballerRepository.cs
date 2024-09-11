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
            Console.WriteLine("coos");
            return playersCount;
        }
    }
}
