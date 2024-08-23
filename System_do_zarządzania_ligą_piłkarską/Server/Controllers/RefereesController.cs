using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;

namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereesController : ControllerBase
    {
        private readonly IRefereeService _refereeService;

        public FootballersController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReferees(int pageNumber = 1, int pageSize = 2)
        {
            var referees = await _refereeService.GetReferees(pageNumber, pageSize);
            return Ok(referees);
        }
    }
}
