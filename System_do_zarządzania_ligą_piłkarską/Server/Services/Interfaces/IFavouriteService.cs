using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IFavouriteService
    {
        Task AddFavourite(FavouriteDTO favouriteDTO);
    }
}
