﻿using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly ApplicationDbContext _context;


        public LeagueRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<LeagueSeason>> GetLeaguesByPage(int pageNumber, int pageSize)
        {
            var leagues = await _context.LeagueSeasons.
                Skip((pageNumber - 1) * pageSize).
                Take(pageSize).
                Include(x => x.LeagueInfo).
                OrderBy(x=>x.LeagueInfo.Name).
                ToListAsync();

            return leagues;
        }

        public async Task<LeagueSeason> GetLeagueById(int id)
        {
            var leagueSeason = await _context.LeagueSeasons.
                Include(x => x.LeagueInfo).
                ThenInclude(x => x.Image).
                FirstOrDefaultAsync(x => x.Id == id);

            Console.WriteLine("test");
            return leagueSeason;
        }

        public async Task<LeagueSeason> GetLeagueSeasonById(int id)
        {
            var league = await _context.LeagueSeasons.FindAsync(id);
            return league;
        }

        public async Task<List<FootballerStat>> GetLeagueScorers(int leagueId)
        {
            var scorers = await _context.FootballerStats
                .Where(x => x.LeagueSeasonId == leagueId
                 && (x.Goals + x.Assists) > 0)
                .Include(x => x.Footballer)
                .ThenInclude(x => x.Team)
                .OrderByDescending(x => x.Goals)
                .ThenByDescending(x => x.Assists)
                .ThenBy(x => x.MatchesPlayed)
                .ToListAsync();

            return scorers;
        }

        public async Task<List<TeamStat>> GetLeagueTable(int leagueId)
        {
            var teamsStats = await _context.TeamStats
                .Where(x => x.LeagueSeasonId == leagueId)
                .Include(x => x.Team)
                .OrderByDescending(x => x.Points)
                .ThenByDescending(x => x.GoalBalance)
                .ToListAsync();

            return teamsStats;
        }

        public async Task AddNewLeagueInfo(LeagueInfo leagueInfo)
        {
            await _context.LeagueInfos.AddAsync(leagueInfo);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewLeagueSeason(LeagueSeason leagueSeason)
        {
            await _context.LeagueSeasons.AddAsync(leagueSeason);
            await _context.SaveChangesAsync();
        }

        // League Master Panel:

        public async Task<List<LeagueInfo>> GetAllLeaguesByLeagueMaster(string leagueMasterId)
        {
            //var leagues = await _context.LeagueSeasons.
            //    Where(x => x.LeagueMasterSecondaryId == leagueMasterId || x.LeagueInfo.LeagueMasterPrimaryId == leagueMasterId).
            //    Include(x => x.LeagueInfo).
            //    Include(x => x.LeagueMasterSecondary).
            //    ToListAsync();

            //return leagues;

            var leagues = await _context.LeagueInfos.
                Where(x => x.LeagueMasterPrimaryId == leagueMasterId || x.LeagueSeasons.Any(y => y.LeagueMasterSecondaryId == leagueMasterId)).
                ToListAsync();

            return leagues;
        }

        public async Task<List<LeagueSeason>> GetLeagueByLeagueMaster(string leagueMasterId, int leagueInfoId)
        {
            var leagues = await _context.LeagueSeasons.
                Where(x => (x.LeagueMasterSecondaryId == leagueMasterId || x.LeagueInfo.LeagueMasterPrimaryId == leagueMasterId) && x.LeagueInfoId == leagueInfoId).
                Include(x => x.LeagueMasterSecondary).
                Include(x => x.LeagueInfo).
                ThenInclude(x=>x.Image).
                ToListAsync();

            return leagues;
        }

        public async Task<LeagueSeason> GetSeasonByLeagueMaster(string leagueMasterId, int leagueInfoId, int leagueSeasonId)
        {
            var leagueSeason = await _context.LeagueSeasons.
                Where(x => (x.LeagueMasterSecondaryId == leagueMasterId || x.LeagueInfo.LeagueMasterPrimaryId == leagueMasterId) && x.LeagueInfoId == leagueInfoId && x.Id == leagueSeasonId).
                Include(x => x.LeagueInfo).
                FirstOrDefaultAsync();

            return leagueSeason;
        }

        public async Task DeleteLeague(int leagueId)
        {
            var leagueToDelete = await _context.LeagueInfos.FindAsync(leagueId);
            _context.LeagueInfos.Remove(leagueToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLeagueSeason(LeagueSeason leagueSeason)
        {
            _context.LeagueSeasons.Update(leagueSeason);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LeagueInfo>> GetLeaguesWithSeasons()
        {
            var leagues = await _context.LeagueInfos.
                Include(x => x.LeagueSeasons).
                ToListAsync();
            return leagues;
        }

        public async Task<LeagueInfo?> GetLeagueInfoById(int leagueInfoId)
        {
            return await _context.LeagueInfos.FindAsync(leagueInfoId);
        }
    }
}
