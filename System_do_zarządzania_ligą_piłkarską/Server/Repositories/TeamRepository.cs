using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;

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

        public async Task AddNewTeam(Team newTeam)
        {
            await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTeam(Team teamToUpdate)
        {
            _context.Teams.Update(teamToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FootballerStat>> GetCurrentFootballersStats(int teamId)
        {
            var currentTeamStatsId = _context.TeamStats.
                Where(x => x.TeamId == teamId && x.CurrentLeague == true).
                Select(x => x.Id).
                FirstOrDefault();

            var currentFootballersStats = await _context.FootballerStats.
                Where(x => x.TeamStatId == currentTeamStatsId).
                Include(x => x.Footballer)
                .ToListAsync();

            return currentFootballersStats;
        }

        public async Task<Team> GetTeamById(int teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            return team;
        }

        public async Task<int> GetCurrentLeagueIdByTeam(int teamId)
        {
            var leagueId = await _context.TeamStats.
                Where(x => x.TeamId == teamId && x.CurrentLeague == true).
                Select(x => x.LeagueSeasonId).
                FirstOrDefaultAsync();

            return leagueId;
        }

        public async Task<List<Match>> GetMatchesByTeam(int teamId, bool isFinished)
        {
            var matches = await _context.Matches.
                Where(x => (x.AwayTeamId == teamId || x.HomeTeamId == teamId) && x.IsFinished == isFinished).
                Include(x => x.HomeTeam).
                Include(x => x.AwayTeam).
                ToListAsync();

            return matches;
        }

        // League Master Panel

        public async Task<Team> GetTeamToManage(int teamId)
        {
            var team = await _context.Teams.
                Include(x=>x.Image).
                Include(x => x.Footballers).
                ThenInclude(x=>x.Image).
                FirstOrDefaultAsync(x => x.Id == teamId);

            return team;
        }

        public async Task AddTeamToTheSeason(TeamStat newTeamStat)
        {
            await _context.TeamStats.AddAsync(newTeamStat);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Team>> GetCreatedTeamsByLeagueMaster(string userId)
        {
            var teams = await _context.Teams.
                Where(x => x.CreatorId == userId).
                Include(x=>x.Coach).
                ToListAsync();

            return teams;
        }

        public async Task DeleteTeam(Team teamToDelete)
        {
            _context.Teams.Remove(teamToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
