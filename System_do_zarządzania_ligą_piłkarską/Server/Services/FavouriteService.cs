using AutoMapper;
using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IMapper _mapper;

        public FavouriteService(IFavouriteRepository favouriteRepository, IMapper mapper)
        {
            _favouriteRepository = favouriteRepository;
            _mapper = mapper;
        }
        public async Task AddFavourite(FavouriteDTO favouriteDTO)
        {
            var favourite = _mapper.Map<Favourite>(favouriteDTO);
            await _favouriteRepository.AddFavourite(favourite);       
        }
    }
}
