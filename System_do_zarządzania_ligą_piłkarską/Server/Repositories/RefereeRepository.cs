using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Drawing.Printing;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;

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
                .Include(x=>x.Image)
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

        // League Master Panel:

        public async Task<List<Referee>> GetAllReferees()
        {
            var referees = await _context.Referees.ToListAsync();
            return referees;
        }

        public async Task<List<Referee>> GetAllRefereesFromSpecificSeason(int leagueSeasonId)
        {
            var referees = await _context.Referees
                 .Include(r => r.RefereeStats.Where(rs => rs.LeagueSeasonId == leagueSeasonId)) 
                 .Where(r => r.RefereeStats.Any(rs => rs.LeagueSeasonId == leagueSeasonId)) 
                 .ToListAsync();

            return referees;
        }

        public async Task AddRefereeToTheSeason(RefereeStat newRefereeStat)
        {
            await _context.RefereeStats.AddAsync(newRefereeStat);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewReferee(Referee newReferee)
        {
            await _context.Referees.AddAsync(newReferee);
            await _context.SaveChangesAsync();
        }
    }
}
