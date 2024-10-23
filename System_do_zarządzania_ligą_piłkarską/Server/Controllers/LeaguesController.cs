using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;
using static System.Net.WebRequestMethods;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        public LeaguesController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeagueSeasonDTO>>> GetLeaguesByPage(int pageNumber, int pageSize)
        {
            var leagues = await _leagueService.GetLeaguesByPage(pageNumber, pageSize);
            return Ok(leagues);
        }

        [HttpGet("{leagueId}")]
        public async Task<ActionResult<List<LeagueSeasonDTO>>> GetLeagueById(int leagueId)
        {
            var league = await _leagueService.GetLeagueById(leagueId);
            return Ok(league);
        }
        [HttpGet("{leagueId}/table")]
        public async Task<ActionResult<List<TeamStatDTO>>> GetLeagueTable(int leagueId)
        {
            var teamsStats = await _leagueService.GetLeagueTable(leagueId);
            return Ok(teamsStats);
        }

        [HttpGet("{leagueId}/scorers")]
        public async Task<ActionResult<List<FootballerStatDTO>>> GetLeagueScorers(int leagueId)
        {
            var scorers = await _leagueService.GetLeagueScorers(leagueId);
            return Ok(scorers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewLeague([FromBody] NewLeagueDTO newLeagueDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _leagueService.CreateNewLeague(newLeagueDto, userId);
            return Ok();
        }



        // LeagueMaster Panel:


        [HttpGet("league-master")]
        [Authorize(Roles = "LeagueMaster")]
        public async Task<IActionResult> GetAllLeaguesByLeagueMaster()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var leagues = await _leagueService.GetAllLeaguesByLeagueMaster(userId);
            return Ok(leagues);
        }

    }
}

