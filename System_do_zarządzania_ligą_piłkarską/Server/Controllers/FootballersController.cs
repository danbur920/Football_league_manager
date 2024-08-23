using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using static System.Net.WebRequestMethods;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballersController : ControllerBase
    {
        private readonly IFootballerService _footballerService;

        public FootballersController(IFootballerService footballerService)
        {
            _footballerService = footballerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers(int pageNumber = 1)
        {
            var players = await _footballerService.GetPlayers(pageNumber);
            return Ok(players);
        }
    }
}

