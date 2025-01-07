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
        public async Task<ActionResult<List<LeagueSeasonDTO>>> GetTeamById([FromRoute] int teamId)
        {
            var team = await _teamService.GetTeamById(teamId);
            return Ok(team);
        }

        [HttpGet("{teamId}/seasons")]
        public async Task<IActionResult> GetSeasonsWithTeamStatsByTeam([FromRoute] int teamId)
        {
            var seasonsTeamStats = await _teamService.GetSeasonsWithTeamStatsByTeam(teamId);
            return Ok(seasonsTeamStats);
        }
        //GetSeasonsWithTeamStatsByTeam

        [HttpPost("league-master")]
        public async Task<IActionResult> AddNewTeam([FromBody] NewTeamDTO newTeam)
        {
            await _teamService.AddNewTeam(newTeam);
            return Ok();
        }

        [HttpDelete("league-master/{teamId}/remove-team")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int teamId)
        {
            await _teamService.DeleteTeam(teamId);
            return Ok();
        }

        [HttpDelete("league-master/{teamId}/remove-coach")]
        public async Task<IActionResult> DeleteCoachFromTeam([FromRoute] int teamId)
        {
            await _teamService.DeleteCoachFromTeam(teamId);
            return Ok();
        }

        [HttpPost("league-master/{teamId}/assign-coach/{coachEmail}")]
        public async Task<IActionResult> AssignCoachToTeam(int teamId, string coachEmail)
        {
            var result = await _teamService.AssignCoachToTeam(teamId, coachEmail);

            if (result)
            {
                return Ok("Trener został przypisany.");
            }
            else
            {
                return BadRequest("Nie udało się przypisać trenera do zespołu.");
            }
        }

        [HttpGet("{teamId}/footballers/stats/current")]
        public async Task<ActionResult<List<FootballerStatDTO>>> GetCurrentFootballersStats(int teamId)
        {
            var stats = await _teamService.GetCurrentFootballersStats(teamId);
            return Ok(stats);
        }

        [HttpGet("{teamId}/matches")]
        public async Task<ActionResult<List<MatchDTO>>> GetMatches([FromRoute] int teamId, [FromQuery] bool isFinished)
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

        [HttpPost("league-master/add-team-to-season")]
        public async Task<IActionResult> AddTeamToTheSeason(NewTeamStatDTO newTeamStatDTO)
        {
            await _teamService.AddTeamToTheSeason(newTeamStatDTO);
            return Ok();
        }

        [HttpGet("league-master/manage-team/{teamId}")]
        public async Task<IActionResult> GetTeamToManage(int teamId)
        {
            var team = await _teamService.GetTeamToManage(teamId);
            return Ok(team);
        }

        //$"api/teams/league-master/manage-team"
        [HttpPatch("league-master/edit-team")]
        public async Task<IActionResult> EditTeam([FromBody] EditTeamDTO editTeam)
        {
            await _teamService.EditTeam(editTeam);
            return Ok();
        }
    }
}
