using Elmo.Application.Services.Exercise4;
using Elmo.Infrastructure.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Elmo.WebApi.Controllers
{
    [Route("api/Exercise4")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class Exercise4Controller : ControllerBase
    {
        private readonly IExercise4Service _Exercise4Service;

        public Exercise4Controller(IExercise4Service Exercise4Service)
        {
            _Exercise4Service = Exercise4Service;
        }

        [HttpGet("IsEmployeeCanRequestVacation")]
        [ProducesResponseType(typeof(State<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEmployeesWithVacationIn2019([Required] int employeeId)
        {
            var result = await _Exercise4Service.IsEmployeeCanRequestVacation(employeeId);
            switch (result.StatusCode)
            {
                case Infrastructure.Common.Models.StatusCode.NotFound: return NotFound(result);
                case Infrastructure.Common.Models.StatusCode.BadRequest: return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
