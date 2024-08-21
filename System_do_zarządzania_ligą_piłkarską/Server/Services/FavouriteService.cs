using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using FavouriteType = System_do_zarządzania_ligą_piłkarską.Shared.DTOs.FavouriteType;



namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public FavouriteService(
            IFavouriteRepository favouriteRepository, 
            IMapper mapper, 
            UserManager<ApplicationUser> userManager, 
            IHttpContextAccessor httpContextAccessor
            )
        {
            _favouriteRepository = favouriteRepository;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AddFavourite(FavouriteDTO favouriteDTO)
        {
            var favourite = _mapper.Map<Favourite>(favouriteDTO);
            await _favouriteRepository.AddFavourite(favourite);
        }

        public async Task<bool> RemoveFavourite(string userId, int favouriteId, string favouriteTypeString)
        {
            if (!Enum.TryParse<FavouriteType>(favouriteTypeString, true, out var favouriteType))
            {
                return false;
            }
            var favourite = await _favouriteRepository.GetFavouriteById(userId, favouriteId, favouriteType);

            if(favourite == null)
            {
                return false;
            }

            await _favouriteRepository.RemoveFavourite(favourite);
            return true;
        }

        public async Task<bool> IsFavourite(string userId, int favouriteId, FavouriteType favouriteType)
        {
            var isFavourite = await _favouriteRepository.GetFavouriteById(userId, favouriteId, favouriteType);

            return isFavourite != null ? true : false;
        }

        public async Task<List<FavouriteDTO>> GetFavouritesByUserId(string userId, string favouriteTypeString)
        {
            Enum.TryParse<FavouriteType>(favouriteTypeString, true, out var favouriteType);
            var favourites = await _favouriteRepository.GetFavouritesByUserId(userId, favouriteType);

            return _mapper.Map<List<FavouriteDTO>>(favourites);
        }

        public async Task<List<LeagueDTO>> GetFavouriteLeaguesByUserId(string userId)
        {
            var favouriteLeagues = await _favouriteRepository.GetFavouriteLeaguesByUserId(userId);
            return _mapper.Map<List<LeagueDTO>>(favouriteLeagues);
        }

        public async Task<List<TeamDTO>> GetFavouriteTeamsByUserId(string userId)
        {
            var favouriteTeams = await _favouriteRepository.GetFavouriteTeamsByUserId(userId);
            return _mapper.Map<List<TeamDTO>>(favouriteTeams);
        }

        public async Task<List<FootballerDTO>> GetFavouriteFootballersByUserId(string userId)
        {
            var favouriteFootballers = await _favouriteRepository.GetFavouriteFootballersByUserId(userId);
            return _mapper.Map<List<FootballerDTO>>(favouriteFootballers);
        }
    }
}
