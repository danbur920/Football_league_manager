using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using FavouriteType = System_do_zarządzania_ligą_piłkarską.Shared.DTOs.FavouriteType;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IFavouriteService
    {
        Task AddFavourite(FavouriteDTO favouriteDTO);
        Task<bool> RemoveFavourite(string userId, int favouriteId, string favouriteType);
        Task<bool> IsFavourite(string userId, int favouriteId, FavouriteType favouriteType);
        Task<List<FavouriteDTO>> GetFavouritesByUserId(string userId, string favouriteType);
    }
}
