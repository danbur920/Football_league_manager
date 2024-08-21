using Microsoft.EntityFrameworkCore;
using System_do_zarządzania_ligą_piłkarską.Server.Data;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using FavouriteType = System_do_zarządzania_ligą_piłkarską.Shared.DTOs.FavouriteType;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavouriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddFavourite(Favourite favourite)
        {
            await _context.Favourites.AddAsync(favourite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFavourite(Favourite favourite)
        {
            _context.Favourites.Remove(favourite);
            await _context.SaveChangesAsync();
        }

        public async Task<Favourite?> GetFavouriteById(string userId, int favouriteId, FavouriteType favouriteType)
        {
            var favouriteTypeConverted = (Models.FavouriteType)favouriteType;

            var result = await _context.Favourites
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FavouriteId == favouriteId && x.FavouriteType == favouriteTypeConverted);

            return result;
        }

        public async Task<List<Favourite>> GetFavouritesByUserId(string userId, FavouriteType favouriteType)
        {
            var favouriteTypeConverted = (Models.FavouriteType)favouriteType;

            var favourites = await _context.Favourites.
                Where(x => x.UserId == userId && x.FavouriteType == favouriteTypeConverted).
                ToListAsync();
            return favourites;
        }

        public async Task<List<League>> GetFavouriteLeaguesByUserId(string userId)
        {
            var userFavourites = await GetFavouritesByUserId(userId, FavouriteType.League);
            var userFavouritesId = userFavourites.Select(x => x.FavouriteId).ToList();

            var userFavouriteLeagues = await _context.Leagues.
                Where(league => userFavouritesId.Contains(league.Id)).
                ToListAsync();
            return userFavouriteLeagues;
        }

        public async Task<List<Team>> GetFavouriteTeamsByUserId(string userId)
        {
            var userFavourites = await GetFavouritesByUserId(userId, FavouriteType.Team);
            var userFavouritesId = userFavourites.Select(x => x.FavouriteId).ToList();

            var userFavouriteTeams = await _context.Teams.
                Where(team => userFavouritesId.Contains(team.Id)).
                ToListAsync();
            return userFavouriteTeams;
        }

        public async Task<List<Footballer>> GetFavouriteFootballersByUserId(string userId)
        {
            var userFavourites = await GetFavouritesByUserId(userId, FavouriteType.Footballer);
            var userFavouritesId = userFavourites.Select(x => x.FavouriteId).ToList();

            var userFavouriteFootballers = await _context.Footballers.
                Where(footballer => userFavouritesId.Contains(footballer.Id)).
                Include(x=>x.Team).
                ToListAsync();

            return userFavouriteFootballers;
        }
    }
}
