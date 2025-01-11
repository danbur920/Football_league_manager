using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IFavouriteService
    {
        Task AddFavourite(FavouriteDTO favouriteDTO);

        // Metody ogólne (przyjmujące favouriteType)
        Task<bool> RemoveFavourite(string userId, int favouriteId, string favouriteType);
        Task<bool> IsFavourite(string userId, int favouriteId, FavouriteType favouriteType);
        Task<List<FavouriteDTO>> GetFavouritesByUserId(string userId, string favouriteType);

        // Metody sprecyzowane:
        Task<List<LeagueSeasonDTO>> GetFavouriteLeaguesByUserId(string userId);
        Task<List<TeamDTO>> GetFavouriteTeamsByUserId(string userId);
        Task<List<FootballerDTO>> GetFavouriteFootballersByUserId(string userId);
        Task<List<RefereeDTO>> GetFavouriteRefereesByUserId(string userId);
    }
}
