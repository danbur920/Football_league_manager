using Duende.IdentityServer.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using static System.Net.WebRequestMethods;
using FavouriteType = System_do_zarządzania_ligą_piłkarską.Shared.DTOs.FavouriteType;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FavouritesController(IFavouriteService favouriteService, IHttpContextAccessor httpContextAccessor)
        {
            _favouriteService = favouriteService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{favouriteType}")]
        public async Task<IActionResult> GetFavourites(string favouriteType)
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            var favourites = await _favouriteService.GetFavouritesByUserId(userId, favouriteType);
            return Ok(favourites);
        }



        [HttpGet("favourite-{favouriteType}")]
        public async Task<IActionResult> GetFavouriteCollection([FromRoute] string favouriteType)
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            switch (favouriteType)
            {
                case "teams":
                    {
                        var favourite = await _favouriteService.GetFavouriteTeamsByUserId(userId);
                        return Ok(favourite);
                    }
                case "footballers":
                    {
                        var favourite = await _favouriteService.GetFavouriteFootballersByUserId(userId);
                        return Ok(favourite);
                    }
                case "leagues":
                    {
                        var favourite = await _favouriteService.GetFavouriteLeaguesByUserId(userId);
                        return Ok(favourite);
                    }
                case "referees":
                    {
                        var favourite = await _favouriteService.GetFavouriteRefereesByUserId(userId);
                        return Ok(favourite);
                    }
            }

            return NotFound();
        }

        // Poniższe 3 metody zostały zastąpione powyższą metodą dynamiczną,
        // wybierającą odpowiednie działanie na podstawie parametru w endpoincie


        //[HttpGet("favourite-teams")]
        //public async Task<IActionResult> GetFavouriteTeams()
        //{
        //    var userId = _httpContextAccessor.HttpContext.User.Identity.GetUserId();

        //    if (userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var favouriteTeams = await _favouriteService.GetFavouriteTeamsByUserId(userId);
        //    return Ok(favouriteTeams);
        //}

        //[HttpGet("favourite-leagues")]
        //public async Task<IActionResult> GetFavouriteLeagues()
        //{
        //    var userId = _httpContextAccessor.HttpContext.User.Identity.GetUserId();

        //    if (userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var favouriteLeagues = await _favouriteService.GetFavouriteLeaguesByUserId(userId);
        //    return Ok(favouriteLeagues);
        //}

        //[HttpGet("favourite-footballers")]
        //public async Task<IActionResult> GetFavouriteFootballers()
        //{
        //    var userId = _httpContextAccessor.HttpContext.User.Identity.GetUserId();

        //    if (userId == null)
        //    {
        //        return Unauthorized();
        //    }

        //    var favouriteFootballers = await _favouriteService.GetFavouriteFootballersByUserId(userId);
        //    return Ok(favouriteFootballers);
        //}

        [HttpPost("{favouriteType}/{favouriteId}")]
        public async Task<IActionResult> AddFavourite(FavouriteType favouriteType, int favouriteId)
        {
            var userId = _httpContextAccessor.HttpContext.User.Identity.GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            var favouriteDTO = new FavouriteDTO
            {
                UserId = userId,
                FavouriteId = favouriteId,
                FavouriteType = favouriteType
            };

            await _favouriteService.AddFavourite(favouriteDTO);
            return Ok();
        }

        [HttpDelete("{favouriteType}/{favouriteId}/{userId}")]
        public async Task<IActionResult> RemoveFavourite(string userId, int favouriteId, string favouriteType)
        {
            if (userId == null)
            {
                return Unauthorized();
            }

            var result = await _favouriteService.RemoveFavourite(userId, favouriteId, favouriteType);

            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("{favouriteType}/{favouriteId}/{userId}")]
        public async Task<bool> IsFavourite(string userId, int favouriteId, FavouriteType favouriteType)
        {
            var result = await _favouriteService.IsFavourite(userId, favouriteId, favouriteType);

            return result;
        }

    }
}
