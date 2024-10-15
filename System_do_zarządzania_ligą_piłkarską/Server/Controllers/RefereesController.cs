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
        public async Task<IActionResult> GetRefereesByPage(int refereeId)
        {
            var referee = await _refereeService.GetRefereeInfoById(refereeId);
            return Ok(referee);
        }
    }
}
