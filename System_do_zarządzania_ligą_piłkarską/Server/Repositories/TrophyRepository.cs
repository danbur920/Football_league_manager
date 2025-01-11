using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class TrophyRepository : ITrophyRepository
    {
        private readonly ApplicationDbContext _context;

        public TrophyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Trophy>> GetTrophies()
        {
            return await _context.Trophies.
                Include(x=>x.Footballer).
                Include(x=>x.Team).
                Include(x=>x.Image).
                ToListAsync();
        }

        public async Task AddTrophy(Trophy trophy)
        {
            await _context.Trophies.AddAsync(trophy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrophy(int trophyId)
        {
            var trophyToDelete = await _context.Trophies.FindAsync(trophyId);
            _context.Trophies.Remove(trophyToDelete);
            await _context .SaveChangesAsync();
        }

        public async Task<List<Trophy>> GetCreatedTrophiesByLeagueMaster(string userId)
        {
            var trophies = await _context.Trophies.
                Where(x => x.CreatorId == userId).
                Include(x=>x.Image).
                ToListAsync();

            return trophies;
        }
    }
}
