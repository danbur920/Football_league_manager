using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Trophies;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TrophiesController : ControllerBase
    {
        private readonly ITrophyService _trophyService;

        public TrophiesController(ITrophyService trophyService)
        {
            _trophyService = trophyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetTrophies()
        {
            var trophies = await _trophyService.GetTrophies();
            return Ok(trophies);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTrophy([FromBody] NewTrophyDTO newTrophy)
        {
            await _trophyService.AddNewTrophy(newTrophy);
            return Ok();
        }

        [HttpGet("league-master/created-trophies")]
        public async Task<IActionResult> GetCreatedTrophiesByLeagueMaster()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var trophies = await _trophyService.GetCreatedTrophiesByLeagueMaster(userId);
            return Ok(trophies);
        }
        //($"api/trophies/league-master/{trophyId}");

        [HttpDelete("league-master/{trophyId}")]
        public async Task<IActionResult> DeleteTrophy([FromRoute] int trophyId)
        {
            await _trophyService.DeleteTrophy(trophyId);
            return Ok();
        }
    }
}
