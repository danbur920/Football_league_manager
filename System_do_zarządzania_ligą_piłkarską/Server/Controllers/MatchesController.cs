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

        [HttpGet("lineup/{matchId}/{teamId}")]
        public async Task<IActionResult> GetLineup(int matchId, int teamId)
        {
            var lineup = await _matchService.GetLineup(matchId, teamId);
            return Ok(lineup);
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

        [HttpPost("league-master/match-footballer")]
        public async Task<IActionResult> AddNewMatchFootballer(NewMatchFootballerDTO newMatchFootballer)
        {
            await _matchService.AddNewMatchFootballer(newMatchFootballer);
            return Ok();
        }

        [HttpDelete("league-master/match-footballer/{matchFootballerId}")]
        public async Task<IActionResult> DeleteMatchFootballer([FromRoute] int matchFootballerId)
        {
            await _matchService.DeleteMatchFootballer(matchFootballerId);
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

        [HttpGet("{matchId}")]
        public async Task<IActionResult> GetMatchDetails([FromRoute] int matchId)
        {
            var match = await _matchService.GetMatchDetails(matchId);
            return Ok(match);
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

        [HttpPatch("league-master/change-match-state/{matchId}")]
        public async Task<IActionResult> ChangeMatchState([FromRoute] int matchId)
        {
            await _matchService.ChangeMatchState(matchId);
            return Ok();
        }
    }
}