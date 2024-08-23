using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Referee>> GetReferees()
        {
            var referees = await _context.Referees.ToListAsync();
            return referees;
        }
    }
}
