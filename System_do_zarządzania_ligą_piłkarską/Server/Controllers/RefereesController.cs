using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Security.Claims;
using System_do_zarządzania_ligą_piłkarską.Server.Services;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Leagues;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Teams;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereesController : ControllerBase
    {
        private readonly IRefereeService _refereeService;

        public RefereesController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRefereesByPage(int pageNumber = 1, int pageSize = 2)
        {
            var referees = await _refereeService.GetRefereesByPage(pageNumber, pageSize);
            return Ok(referees);
        }

        [HttpGet("{refereeId}")]
        public async Task<IActionResult> GetRefereeById(int refereeId)
        {
            var referee = await _refereeService.GetRefereeInfoById(refereeId);
            return Ok(referee);
        }



        // League Master Panel:

        [HttpGet("league-master/manage-referee/{refereeId}")]
        public async Task<IActionResult> GetRefereeToManage(int refereeId)
        {
            var referee = await _refereeService.GetRefereeToManage(refereeId);
            return Ok(referee);
        }

        [HttpGet("league-master/all")]
        public async Task<IActionResult> GetAllRefereesForLeagueMaster()
        {
            var referees = await _refereeService.GetAllRefereesForLeagueMaster();
            return Ok(referees);
        }

        [HttpGet("league-master/specific-season/{leagueSeasonId}")]
        public async Task<IActionResult> GetAllRefereesFromSpecificSeasonForLeagueMaster(int leagueSeasonId)
        {
            var referees = await _refereeService.GetAllRefereesFromSpecificSeason(leagueSeasonId);
            return Ok(referees);
        }

        [HttpPost("league-master")]
        public async Task<IActionResult> AddRefereeToTheSeason(NewRefereeStatDTO newRefereeDTO)
        {
            await _refereeService.AddRefereeToTheSeason(newRefereeDTO);
            return Ok();
        }

        [HttpPost("league-master/add-new-referee")]
        public async Task<IActionResult> AddNewReferee(NewRefereeDTO newReferee)
        {
            await _refereeService.AddNewReferee(newReferee);
            return Ok();
        }

        [HttpGet("league-master/created-referees")]
        public async Task<IActionResult> GetCreatedRefereesByLeagueMaster()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var referees = await _refereeService.GetCreatedRefereesByLeagueMaster(userId);
            return Ok(referees);
        }

        [HttpPatch("league-master/edit-referee")]
        public async Task<IActionResult> EditReferee([FromBody] RefereeInfoDTO editReferee)
        {
            await _refereeService.EditReferee(editReferee);
            return Ok();
        }
    }
}
