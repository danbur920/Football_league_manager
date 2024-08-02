using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using static System.Net.WebRequestMethods;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        //league = await Http.GetFromJsonAsync<LeagueDTO>($"api/leagues/{leagueId}");
        //teamStats = await Http.GetFromJsonAsync<TeamStatDTO[]>($"api/leagues/{leagueId}/team-stats");

        public LeaguesController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeagueDTO>>> GetAllLeagues()
        {
            var leagues = await _leagueService.GetAllLeagues();
            return Ok(leagues);
        }

        [HttpGet("{leagueId}")]
        public async Task<ActionResult<List<LeagueDTO>>> GetLeagueById(int leagueId)
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
    }
}
