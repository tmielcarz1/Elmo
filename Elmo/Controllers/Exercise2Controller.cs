using Elmo.Application.Models.Exercise2;
using Elmo.Application.Services.Exercise2;
using Elmo.Infrastructure.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Elmo.WebApi.Controllers
{
    [Route("api/Exercise2")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class Exercise2Controller : ControllerBase
    {
        private readonly IExercise2Service _Exercise2Service;

        public Exercise2Controller(IExercise2Service Exercise2Service)
        {
            _Exercise2Service = Exercise2Service;
        }

        [HttpGet("GetEmployeesWithVacationIn2019")]
        [ProducesResponseType(typeof(State<GetEmployeesWithVacationIn2019Response>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEmployeesWithVacationIn2019()
        {
            var result = await _Exercise2Service.GetEmployeesWithVacationIn2019();
            switch (result.StatusCode)
            {
                case Infrastructure.Common.Models.StatusCode.NotFound: return NotFound(result);
                case Infrastructure.Common.Models.StatusCode.BadRequest: return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetEmployeesWithGrantedDaysThisYear")]
        [ProducesResponseType(typeof(State<GetEmployeesWithGrantedDaysThisYearResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEmployeesWithGrantedDaysThisYear()
        {
            var result = await _Exercise2Service.GetEmployeesWithGrantedDaysThisYear();
            switch (result.StatusCode)
            {
                case Infrastructure.Common.Models.StatusCode.NotFound: return NotFound(result);
                case Infrastructure.Common.Models.StatusCode.BadRequest: return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetTeamsWithoutVataionIn2019")]
        [ProducesResponseType(typeof(State<GetTeamsWithoutVacationIn2019Response>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTeamsWithoutVataionIn2019()
        {
            var result = await _Exercise2Service.GetTeamsWithoutVataionIn2019();
            switch (result.StatusCode)
            {
                case Infrastructure.Common.Models.StatusCode.NotFound: return NotFound(result);
                case Infrastructure.Common.Models.StatusCode.BadRequest: return BadRequest(result);
            }

            return Ok(result);
        }


    }
}
