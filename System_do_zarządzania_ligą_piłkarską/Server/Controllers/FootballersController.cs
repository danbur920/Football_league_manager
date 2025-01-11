using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Text.Json;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Footballers;
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
        public async Task<IActionResult> GetPlayersByPage([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 2)
        {
            var players = await _footballerService.GetPlayersByPage(pageNumber, pageSize);
            return Ok(players);
        }

        [HttpGet("team/{teamId}")]
        public async Task<IActionResult> GetFootballersFromSpecificTeam([FromRoute] int teamId)
        {
            var players = await _footballerService.GetFootballersFromSpecificTeam(teamId);
            return Ok(players);
        }

        [HttpGet("season/{leagueSeasonId}")]
        public async Task<IActionResult> GetBasicFootballerInfoFromSpecificSeason([FromRoute] int leagueSeasonId)
        {
            var players = await _footballerService.GetBasicFootballerInfoFromSpecificSeason(leagueSeasonId);
            return Ok(players);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetTotalPlayersCount()
        {
            var playersCount = await _footballerService.GetTotalPlayersCount();
            return Ok(playersCount); 
        }

        [HttpGet("{footballerId}")]
        public async Task<IActionResult> GetFootballerInfoById(int footballerId)
        {
            var footballer = await _footballerService.GetFootballerInfoById(footballerId);
            return Ok(footballer);
        }

        [HttpGet("stats/{footballerId}")]
        public async Task<IActionResult> GetFootballerStatsById(int footballerId)
        {
            var footballerStats = await _footballerService.GetFootballerStatsById(footballerId);
            return Ok(footballerStats);
        }

        [HttpPost("league-master/add-new-footballer-to-team")]
        public async Task<IActionResult> AddNewFootballerToTeam([FromBody] NewFootballerDTO newFootballer)
        {
            await _footballerService.AddNewFootballerToTeam(newFootballer);
            return Ok();
        }
    }
}

