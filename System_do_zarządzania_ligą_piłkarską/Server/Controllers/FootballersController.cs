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

        //[HttpGet("{teamId}/scorers")]
        //public async Task<ActionResult<List<FootballerStatDTO>>> GetLeagueScorers(int teamId)
        //{
        //    var scorers = await _leagueService.GetLeagueScorers(leagueId);
        //    return Ok(scorers);
        //}


        //private FootballerStatDTO[]? teamLineup;

        //protected override async Task OnInitializedAsync()
        //{
        //    teamLineup = await Http.GetFromJsonAsync<FootballerStatDTO[]>($"api/footballers/{teamId}/lineup");
        //}
    }
}
