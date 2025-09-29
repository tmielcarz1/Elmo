using Elmo.Application.Models.Exercise3;
using Elmo.Application.Services.Exercise3;
using Elmo.Infrastructure.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Elmo.WebApi.Controllers
{
    [Route("api/Exercise3")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class Exercise3Controller : ControllerBase
    {
        private readonly IExercise3Service _Exercise3Service;

        public Exercise3Controller(IExercise3Service Exercise3Service)
        {
            _Exercise3Service = Exercise3Service;
        }

        [HttpGet("GetEmployeeRemainingVacationThisYearResponse")]
        [ProducesResponseType(typeof(State<GetEmployeeRemainingVacationThisYearResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEmployeesWithVacationIn2019([Required] int employeeId)
        {
            var result = await _Exercise3Service.GetEmployeeRemainingVacationThisYearResponse(employeeId);
            switch (result.StatusCode)
            {
                case Infrastructure.Common.Models.StatusCode.NotFound: return NotFound(result);
                case Infrastructure.Common.Models.StatusCode.BadRequest: return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
