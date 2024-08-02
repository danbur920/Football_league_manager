using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouritesController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpPost("{favouriteType}/{id}")]
        public async Task<IActionResult> AddFavouriteLeague(FavouriteType favouriteType, int id)
        {
            var userId = User.FindFirst(c => c.Type == "sub")?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            var favouriteDTO = new FavouriteDTO
            {
                UserId = userId,
                FavouriteId = id,
                FavouriteType = favouriteType
            };

            await _favouriteService.AddFavourite(favouriteDTO);
            return Ok();
        }
    }
}
