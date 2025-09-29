using Elmo.Application.Models.Exercise1;
using Elmo.Application.Services.Exercise1;
using Elmo.Infrastructure.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Elmo.WebApi.Controllers
{
    [Route("api/Exercise1")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class Exercise1Controller : ControllerBase
    {
        private readonly IExercise1Service _exercise1Service;

        public Exercise1Controller(IExercise1Service exercise1Service)
        {
            _exercise1Service = exercise1Service;
        }

        [HttpPost(Name = "GetSuperiorRowOfEmployee")]
        [ProducesResponseType(typeof(State<int?>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(State), (int)HttpStatusCode.NotFound)]
        public IActionResult GetSuperiorRowOfEmployee(GetSuperiorRowOfEmployeeRequest request)
        {
            var result = _exercise1Service.GetSuperiorRowOfEmployee(request.EmployeeId, request.SuperiorId);
            if (result.IsNotValid)
                switch (result.StatusCode)
                {
                    case Infrastructure.Common.Models.StatusCode.NotFound: return NotFound(result);
                    case Infrastructure.Common.Models.StatusCode.BadRequest: return BadRequest(result);
                }

            return Ok(result);
        }

    }
}
