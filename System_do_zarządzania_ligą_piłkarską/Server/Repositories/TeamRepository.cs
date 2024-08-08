using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Team>> GetAllTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return teams;
        }

        public async Task<List<FootballerStat>> GetCurrentFootballersStats(int teamId)
        {
            var currentTeamStatsId = _context.TeamStats.
                Where(x=>x.TeamId == teamId && x.CurrentLeague == true).
                Select(x=>x.Id).
                FirstOrDefault();

            var currentFootballersStats = await _context.FootballerStats.
                Where(x=>x.TeamStatId==currentTeamStatsId)
                .ToListAsync();

            return currentFootballersStats;
        }

        public async Task<Team> GetTeamById(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            return team;
        }
    }
}
