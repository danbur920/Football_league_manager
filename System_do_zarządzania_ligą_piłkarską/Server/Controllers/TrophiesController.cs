using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;

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
    }
}
