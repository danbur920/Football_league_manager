using System_do_zarządzania_ligą_piłkarską.Server.Models;
using FavouriteType = System_do_zarządzania_ligą_piłkarską.Shared.DTOs.FavouriteType;

namespace System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces
{
    public interface IFavouriteRepository
    {
        Task AddFavourite(Favourite favourite);
        Task RemoveFavourite(Favourite favourite);
        Task<Favourite?> GetFavouriteById(string userId, int favouriteId, FavouriteType favouriteType);
        Task<List<Favourite>> GetFavouritesByUserId(string userId, FavouriteType favouriteType);

        // Metody sprecyzowane:

        Task<List<League>> GetFavouriteLeaguesByUserId(string userId);
        Task<List<Team>> GetFavouriteTeamsByUserId(string userId);
        Task<List<Footballer>> GetFavouriteFootballersByUserId(string userId);
    }
}
