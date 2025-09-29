using Elmo.Application.Models.Exercise3;
using Elmo.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmo.Application.Services.Exercise3
{
    public interface IExercise3Service
    {
        Task<State<GetEmployeeRemainingVacationThisYearResponse>> GetEmployeeRemainingVacationThisYearResponse(int employeeId);
    }
}
