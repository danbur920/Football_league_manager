using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamDTO>>> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeams();
            return Ok(teams);
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<List<LeagueSeasonDTO>>> GetTeamById(int teamId)
        {
            var team = await _teamService.GetTeamById(teamId);
            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTeam(NewTeamDTO newTeam)
        {
            await _teamService.AddNewTeam(newTeam);
            return Ok();
        }

        [HttpDelete("{teamId}/remove-team")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int teamId)
        {
            await _teamService.DeleteTeam(teamId);
            return Ok();
        }

        [HttpDelete("{teamId}/remove-coach")]
        public async Task<IActionResult> DeleteCoachFromTeam([FromRoute] int teamId)
        {
            await _teamService.DeleteCoachFromTeam(teamId);
            return Ok();
        }

        [HttpGet("{teamId}/footballers/stats/current")]
        public async Task<ActionResult<List<FootballerStatDTO>>> GetCurrentFootballersStats(int teamId)
        {
            var stats = await _teamService.GetCurrentFootballersStats(teamId);
            return Ok(stats);
        }

        [HttpGet("{teamId}/matches")]
        public async Task<ActionResult<List<MatchDTO>>> GetMatches(int teamId, [FromQuery] bool isFinished)
        {
            var matches = await _teamService.GetMatchesByTeam(teamId, isFinished);
            return Ok(matches);
        }

        // League Master Panel:

        [HttpGet("league-master/all")]
        public async Task<IActionResult> GetAllTeamsForLeagueMaster()
        {
            var teams = await _teamService.GetAllTeamsForLeagueMaster();
            return Ok(teams);
        }

        [HttpGet("league-master/created-teams")]
        public async Task<IActionResult> GetCreatedTeamsByLeagueMaster()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var teams = await _teamService.GetCreatedTeamsByLeagueMaster(userId);
            return Ok(teams);
        }

        [HttpPost("league-master")]
        public async Task<IActionResult> AddTeamToTheSeason(NewTeamStatDTO newTeamStatDTO)
        {
            await _teamService.AddTeamToTheSeason(newTeamStatDTO);
            return Ok();
        }
    }
}
