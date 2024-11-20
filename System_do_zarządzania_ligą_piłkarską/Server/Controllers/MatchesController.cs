using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Matches;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // League Master Panel:

        [HttpPost("league-master")]
        public async Task<IActionResult> AddNewMatchToTheSeason(NewMatchDTO newMatch)
        {
            await _matchService.AddNewMatchToTheSeason(newMatch);
            return Ok();
        }

        [HttpPost("league-master/match-event")]
        public async Task<IActionResult> AddNewMatchEventToTheSeason(MatchEventDTO newMatchEvent)
        {
            await _matchService.AddNewMatchEventToTheSeason(newMatchEvent);
            return Ok();
        }

        [HttpDelete("league-master/match-event/{matchEventId}")]
        public async Task<IActionResult> DeleteMatchEvent([FromRoute] int matchEventId)
        {
            await _matchService.DeleteMatchEventFromSeason(matchEventId);
            return Ok();
        }

        [HttpGet("league-master/{leagueSeasonId}")]
        public async Task<IActionResult> GetMatchesFromSpecificSeasonForLeagueMaster([FromRoute] int leagueSeasonId)
        {
            var matches = await _matchService.GetMatchesFromSpecificSeasonForLeagueMaster(leagueSeasonId);
            return Ok(matches);
        }

        [HttpGet("league-master/match/{leagueSeasonId}/{matchId}")]
        public async Task<IActionResult> GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster([FromRoute] int leagueSeasonId, [FromRoute] int matchId)
        {
            var match = await _matchService.GetExtensiveMatchInfoFromSpecificSeasonForLeagueMaster(leagueSeasonId, matchId);
            return Ok(match);
        }

        [HttpPatch("league-master")]
        public async Task<IActionResult> UpdateMatchInfo([FromBody] EditMatchDTO editMatch)
        {
            if (editMatch == null)
            {
                return BadRequest("Dane meczu są niepoprawne.");
            }

            await _matchService.UpdateMatchInfo(editMatch);
            return Ok();
        }
    }
}