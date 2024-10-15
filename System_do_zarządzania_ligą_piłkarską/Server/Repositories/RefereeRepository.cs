using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class RefereeRepository : IRefereeRepository
    {
        private readonly ApplicationDbContext _context;

        public RefereeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Referee> GetRefereeInfoById(int refereeId)
        {
            var referee = await _context.Referees
                .Where(x => x.Id == refereeId)
                .Include(x => x.RefereeStats)       
                .FirstOrDefaultAsync();

            return referee;
        }

        public async Task<List<Referee>> GetRefereesByPage(int pageNumber, int pageSize)
        {
            var referees = await _context.Referees.
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).
                ToListAsync();
            return referees;
        }
    }
}
