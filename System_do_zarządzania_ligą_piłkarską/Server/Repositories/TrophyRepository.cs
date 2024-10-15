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
                ToListAsync();
        }
    }
}
